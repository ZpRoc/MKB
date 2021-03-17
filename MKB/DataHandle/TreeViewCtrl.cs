using System;
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
            // 创建新节点，并添加
            TreeNode treeNode = new TreeNode();
            treeNode.Text     = "C00 " + cmdConfig.m_descr;
            treeNode.Tag      = cmdConfig;

            if (treeView.SelectedNode.Level == 1)           // 选中的是命令节点
                treeView.SelectedNode.Parent.Nodes.Insert(treeView.SelectedNode.Index + 1, treeNode);
            else if (treeView.SelectedNode.Level == 0)      // 选中的是命令组节点
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
            // 创建新节点，并添加
            TreeNode treeNode = new TreeNode();
            treeNode.Text     = "G00 " + grpConfig.m_descr;
            treeNode.Tag      = grpConfig;

            if (treeView.SelectedNode != null)
            {
                if (treeView.SelectedNode.Level == 1)           // 选中的是命令节点
                    treeView.SelectedNode.Parent.TreeView.Nodes.Insert(treeView.SelectedNode.Parent.Index + 1, treeNode);
                else if (treeView.SelectedNode.Level == 0)      // 选中的是命令组节点
                    treeView.SelectedNode.TreeView.Nodes.Insert(treeView.SelectedNode.Index + 1, treeNode);
            }
            else
            {
                treeView.Nodes.Add(treeNode);
            }

            // 将新节点设置为选中状态
            treeView.SelectedNode = treeNode;

            // 刷新节点文本，并返回
            RefreshText(treeView);
            return null;
        }

        /// <summary>
        /// 编辑新命令节点
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="cmdConfig">命令 数据</param>
        /// <returns></returns>
        public string EditCmd(TreeView treeView, CmdConfig cmdConfig)
        {
            // 编辑节点
            treeView.SelectedNode.Text = treeView.SelectedNode.Text.Substring(0, 4) + cmdConfig.m_descr;
            treeView.SelectedNode.Tag  = cmdConfig;

            // 返回
            return null;
        }

        /// <summary>
        /// 编辑新命令组节点
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="grpConfig">命令组 数据</param>
        /// <returns></returns>
        public string EditGrp(TreeView treeView, GrpConfig grpConfig)
        {
            // 编辑节点
            treeView.SelectedNode.Text = treeView.SelectedNode.Text.Substring(0, 4) + grpConfig.m_descr;
            treeView.SelectedNode.Tag = grpConfig;

            // 返回
            return null;
        }

        /// <summary>
        /// 复制 命令/命令组 节点
        /// </summary>
        /// <param name="treeView"></param>
        /// <returns></returns>
        public string CopyNode(TreeView treeView)
        {
            // 复制节点
            treeView.Tag = treeView.SelectedNode;

            // 返回
            return null;
        }

        /// <summary>
        /// 粘贴 命令/命令组 节点
        /// </summary>
        /// <param name="treeView"></param>
        /// <returns></returns>
        public string PasteNode(TreeView treeView)
        {
            // 确保已经复制过节点
            if (treeView.Tag == null)
                return "节点未复制！";

            // 确保节点一致
            if (treeView.SelectedNode.Level != ((TreeNode)treeView.Tag).Level)
            {
                return "当前选中节点与所复制节点的级别不一致！";
            }

            // 粘贴 命令/命令组
            TreeNode newNode = (TreeNode)((TreeNode)treeView.Tag).Clone();
            if (treeView.SelectedNode.Level == 1)
            {
                treeView.SelectedNode.Parent.Nodes.Insert(treeView.SelectedNode.Index + 1, newNode);
            }
            else if (treeView.SelectedNode.Level == 0)
            {
                treeView.SelectedNode.TreeView.Nodes.Insert(treeView.SelectedNode.Index + 1, newNode);
            }

            // 将新节点设置为选中状态
            treeView.SelectedNode = newNode;

            // 刷新节点文本，并返回
            RefreshText(treeView);
            return null;
        }

        /// <summary>
        /// 删除 命令/命令组 节点
        /// </summary>
        /// <param name="treeView"></param>
        /// <returns></returns>
        public string DeleteNode(TreeView treeView)
        {
            // 删除节点
            treeView.SelectedNode.Remove();

            // 刷新节点文本，并返回
            RefreshText(treeView);
            return null;
        }

        /// <summary>
        /// 上移 命令/命令组 节点
        /// </summary>
        /// <param name="treeView"></param>
        /// <returns></returns>
        public string MoveUpNode(TreeView treeView)
        {
            // 指定节点为空，或者指定节点处于首位
            if (treeView.SelectedNode == null || treeView.SelectedNode.PrevNode == null)
                return null;

            // 克隆该节点，并删除
            int prevIndex = treeView.SelectedNode.PrevNode.Index;
            TreeNode newNode = (TreeNode)treeView.SelectedNode.Clone();
            treeView.SelectedNode.TreeView.Nodes.Remove(treeView.SelectedNode);

            // 节点移动
            if (treeView.SelectedNode.Parent != null)
                treeView.SelectedNode.Parent.Nodes.Insert(prevIndex, newNode);
            else
                treeView.SelectedNode.TreeView.Nodes.Insert(prevIndex, newNode);

            // 将移动后节点设置为选中状态
            treeView.SelectedNode.TreeView.SelectedNode = newNode;

            // 刷新节点文本，并返回
            RefreshText(treeView);
            return null;
        }

        /// <summary>
        /// 下移 命令/命令组 节点
        /// </summary>
        /// <param name="treeView"></param>
        /// <returns></returns>
        public string MoveDnNode(TreeView treeView)
        {
            // 指定节点为空，或者指定节点处于末位
            if (treeView.SelectedNode == null || treeView.SelectedNode.NextNode == null)
                return null;

            // 克隆该节点，并删除
            int nextIndex = treeView.SelectedNode.NextNode.Index;
            TreeNode newNode = (TreeNode)treeView.SelectedNode.Clone();
            treeView.SelectedNode.TreeView.Nodes.Remove(treeView.SelectedNode);

            // 节点移动
            if (treeView.SelectedNode.Parent != null)
                treeView.SelectedNode.Parent.Nodes.Insert(nextIndex, newNode);
            else
                treeView.SelectedNode.TreeView.Nodes.Insert(nextIndex, newNode);

            // 将移动后节点设置为选中状态
            treeView.SelectedNode.TreeView.SelectedNode = newNode;

            // 刷新节点文本，并返回
            RefreshText(treeView);
            return null;
        }

        // -------------------------------------------------------------------------------- //
        // ---------------------------------- Functions ----------------------------------- //
        // -------------------------------------------------------------------------------- //

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
