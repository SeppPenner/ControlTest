using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace ControlTest
{
    internal class LedDesigner : ControlDesigner
    {
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                base.ActionLists.Clear();
                base.ActionLists.Add(new LedActionList(Component));
                return base.ActionLists;
            }
        }
    }
}