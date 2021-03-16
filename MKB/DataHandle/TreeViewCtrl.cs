using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MKB.DataHandle
{
    /// <summary>
    /// TreeViewCtrl:
    ///     TreeView 控件的相关控制函数
    /// Function:
    ///     
    /// Variable:
    ///     
    /// Note:
    ///     None. 
    /// </summary>
    public class TreeViewCtrl
    {


        // -------------------------------------------------------------------------------- //
        // ----------------------------------- Control ------------------------------------ //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 创建新命令节点
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="cmdConfig">命令 数据</param>
        /// <returns></returns>
        public string CreateCmd(TreeView treeView, CmdConfig cmdConfig)
        {
            // 添加 CmdNode 的时候，必须选中某一个 GrpNode
            if (treeView.SelectedNode == null)
                return "仅允许在命令组下添加命令，请选中命令组节点或命令节点后再添加！";

            // 创建新节点，并添加
            TreeNode treeNode = new TreeNode();
            treeNode.Text     = "C00 " + cmdConfig.m_descr;
            treeNode.Tag      = cmdConfig;

            if (treeView.SelectedNode.Level == 1)
                treeView.SelectedNode.Parent.Nodes.Insert(treeView.SelectedNode.Index + 1, treeNode);
            else if (treeView.SelectedNode.Level == 0)
                treeView.SelectedNode.Nodes.Add(treeNode);

            // 将新节点设置为选中状态
            treeView.SelectedNode = treeNode;

            // 刷新节点文本，并返回
            RefreshText(treeView);
            return null;
        }

        /// <summary>
        /// 创建新命令组节点
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="grpConfig">命令组 数据</param>
        /// <returns></returns>
        public string CreateGrp(TreeView treeView, GrpConfig grpConfig)
        {
            // 添加 GrpNode 的时候，必须处于根目录状态
            if (treeView.SelectedNode != null && treeView.SelectedNode.Level != 0)
                return "仅允许在根目录下添加命令组，请选中根目录节点后再添加！";

            // 创建新节点，并添加
            TreeNode treeNode = new TreeNode();
            treeNode.Text     = "G00 " + grpConfig.m_name;
            treeNode.Tag      = grpConfig;

            if (treeView.SelectedNode != null)
                treeView.Nodes.Insert(treeView.SelectedNode.Index + 1, treeNode);
            else
                treeView.Nodes.Add(treeNode);

            // 将新节点设置为选中状态
            treeView.SelectedNode = treeNode;

            // 刷新节点文本，并返回
            RefreshText(treeView);
            return null;
        }

        // -------------------------------------------------------------------------------- //
        // ---------------------------------- Functions ----------------------------------- //
        // -------------------------------------------------------------------------------- //

        public string NodeUp(TreeNode node)
        {
            // 指定节点为空，或者指定节点处于首位
            if (node == null || node.PrevNode == null)
                return null;

            // 克隆该节点
            TreeNode newNode = (TreeNode)node.Clone();

            // 节点移动
            if (node.Parent != null)
                node.Parent.Nodes.Insert(node.PrevNode.Index, newNode);
            else
                node.TreeView.Nodes.Insert(node.PrevNode.Index, newNode);

            node.TreeView.SelectedNode = newNode;
            node.TreeView.Nodes.Remove(node);

            return null;
        }

        public string NodeDown(TreeNode node)
        {
            // 指定节点为空，或者指定节点处于末位
            if (node == null || node.NextNode == null)
                return null;

            // 克隆该节点
            TreeNode newNode = (TreeNode)node.Clone();

            // 节点移动
            if (node.Parent != null)
                node.Parent.Nodes.Add(newNode);
            else
                node.TreeView.Nodes.Add(newNode);

            node.TreeView.SelectedNode = newNode;
            node.TreeView.Nodes.Remove(node);

            return null;
        }

        /// <summary>
        /// 改变节点编号
        /// </summary>
        /// <param name="oldStr"></param>
        /// <param name="newCnt"></param>
        /// <returns></returns>
        private string ReCnt(string oldStr, int newCnt)
        {
            // 编号范围为 00-->99（应在添加 Node 前进行判断）
            newCnt = (newCnt < 0)  ?  0 : newCnt;
            newCnt = (newCnt > 99) ? 99 : newCnt;

            // 仅改变 oldStr 的编号位（"G?? Comment" OR "C?? Comment"）
            return (oldStr[0].ToString() + newCnt.ToString("#00") + oldStr.Substring(3, oldStr.Length - 3));
        }

        /// <summary>
        /// 刷新 TreeView 的所有 Text
        /// </summary>
        /// <param name="treeView"></param>
        /// <returns></returns>
        private void RefreshText(TreeView treeView)
        {
            // 0 级节点：Group
            for (int g = 0; g < treeView.Nodes.Count; g++)
            {
                treeView.Nodes[g].Text = ReCnt(treeView.Nodes[g].Text, g);

                // 1 级节点：Cmd
                for (int c = 0; c < treeView.Nodes[g].Nodes.Count; c++)
                {
                    treeView.Nodes[g].Nodes[c].Text = ReCnt(treeView.Nodes[g].Nodes[c].Text, c);
                }
            }

            // 焦点不变
            treeView.Focus();
        }
    }
}
