﻿

#pragma checksum "C:\Users\Andrei\Documents\4Puzzle\4Puzzle\4Puzzle\SinglePlayer\SinglePlayerMenu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1DC96C531B8FB1056E5A098CB79F1C1F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _4Puzzle
{
    partial class SinglePlayerMenu : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 17 "..\..\SinglePlayer\SinglePlayerMenu.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.SinglePlayerEasy_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 25 "..\..\SinglePlayer\SinglePlayerMenu.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.SinglePlayerMedium_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 33 "..\..\SinglePlayer\SinglePlayerMenu.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.SinglePlayerHard_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 43 "..\..\SinglePlayer\SinglePlayerMenu.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.imageSound_Tapped;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


