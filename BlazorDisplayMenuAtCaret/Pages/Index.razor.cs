using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorDisplayMenuAtCaret.Pages
{
    public partial class Index
    {

        public string DivStyle { get; set; } = "display:none;";


        private void cmdOnClick(MouseEventArgs args)
        {
            CmdHideContextMenu();
        }

        private void cmdOnKeyPress(KeyboardEventArgs args)
        {

            if (args.Key == "@")
            {
                CmdDisplayContextMenu("CSTemplate");
            }
            else
            {
                CmdHideContextMenu();
            }
        }


        public async void CmdDisplayContextMenu(string ElementID)
        {

            int Y = (int)(await MyJsInterop.GetElementActualTop(ElementID));
            int X = (int)(await MyJsInterop.GetElementActualLeft(ElementID));


            //JS code for caret coordinates comes from this repo
            //https://github.com/component/textarea-caret-position
            string a = await MyJsInterop.getCaretCoordinates("CSTemplate");

            string[] b = a.Split(',');

            Y += int.Parse(b[0]) + 30;
            X += int.Parse(b[1]) - 20;

            DivStyle = "width:200px;height:100px;top:" + Y + "px;" + "left:" + X + "px";

            this.StateHasChanged();
        }

        public void CmdHideContextMenu()
        {
            if (!DivStyle.Equals("display:none;"))
            {

                DivStyle = "display:none;";
            }
        }

  }
}
