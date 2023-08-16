using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using INGP.UploadGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INGP_Tools
{
    public static class RevitApi

    {

        public static void Init(UIControlledApplication app)
        {

            UicApp = app;

            GeneralEvent = new GeneralExternalEvent();
            GeneralExternalEvent = ExternalEvent.Create(GeneralEvent);
        }

        public static void Init(UIApplication app)
        {
            if (UiApplication != null)
            {
                return;
            }
            UiApplication = app;
        }
        public static UIApplication UiApplication { get; set; }
        public static UIDocument UiDoc => UiApplication.ActiveUIDocument;
        public static Document Doc => UiApplication.ActiveUIDocument.Document;


        public static ExternalEvent GeneralExternalEvent { get; set; }
        public static GeneralExternalEvent GeneralEvent { get; set; }
        public static UIControlledApplication UicApp { get; private set; }


    }
}
