using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using INGP.UploadGroup;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace INGP_Tools
{
    [Regeneration(RegenerationOption.Manual)]
    public class ExternalApp : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "INGP_Tools";
            RevitApi.Init(application);

            CreateRibbon(application, tabName);

            return Result.Succeeded;
        }



        private void CreateRibbon(UIControlledApplication app, string tabName)
        {
            CreateGeneralPanel(app, tabName);
        }

        private static void CreateGeneralPanel(UIControlledApplication app, string tabName)
        {
            string generalPanelName = "Общее";
            //string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            //string iconsDirecotryPath = Path.GetDirectoryName(assemblyLocation) + @"\Resources\Icons\";

            app.CreateRibbonTab(tabName);
            RibbonPanel generalPanel = app.CreateRibbonPanel(tabName, generalPanelName);

            ImageSource imageSource = ImageUtils.GetImageByResource(Resource1.UploadGroupCmd_32x32);
            AddButtonOnPanel(generalPanel, typeof(UploadGroupCmd), "Выгрузить группу", "Выгрузить группу", imageSource);

        }

        private static void AddButtonOnPanel(RibbonPanel panelGeneral, Type cmdType, string btnVisibleText, string toolTip, ImageSource imageSource)
        {
            PushButtonData btn_AboutPlugin = new PushButtonData(
                cmdType.FullName,
                btnVisibleText,
                 cmdType.Assembly.Location,
                 cmdType.FullName);

            btn_AboutPlugin.ToolTip = toolTip;
            //btn_AboutPlugin.LargeImage = ImageUtils.GetBitmapImage(iconsDirecotryPath, "AboutPluginCmd.ico");
            btn_AboutPlugin.LargeImage = imageSource;
            panelGeneral.AddItem(btn_AboutPlugin);
        }

        private static void AddButtonOnSplitButton(SplitButton splitButton, Type cmdType, string btnVisibleText, string toolTip, ImageSource imageSource)
        {
            PushButtonData btn_AboutPlugin = new PushButtonData(
                cmdType.FullName,
                btnVisibleText,
                 cmdType.Assembly.Location,
                 cmdType.FullName);

            btn_AboutPlugin.ToolTip = toolTip;
            //btn_AboutPlugin.LargeImage = ImageUtils.GetBitmapImage(iconsDirecotryPath, "AboutPluginCmd.ico");
            btn_AboutPlugin.LargeImage = imageSource;
            splitButton.AddPushButton(btn_AboutPlugin);
        }


        private PushButtonData AddBtn(string asseblyLocation, string commandClassName, string buttonNameVisible)
        {
            var text = commandClassName.Split('.').LastOrDefault();
            var pushBtn = new PushButtonData(text, buttonNameVisible, asseblyLocation, commandClassName);
            return pushBtn;
        }



    }
}
