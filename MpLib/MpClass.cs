using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpatialAnalyzerSDK;
using System.Runtime.InteropServices;

namespace MpLib
{
    //public class SDKHelper
    //{

    //}
    public class MpClass
    {
        public MpClass(string _SAPath, string _FilePath)
        {
            ProcessOp op = new ProcessOp();
            op.OpenSA(_SAPath, _FilePath);
        }
        private ISpatialAnalyzerSDK NrkSdk;

        private String ErrorMsg;

        public string GetMsg()
        {
            return ErrorMsg;
        }

        enum MPStatus
        {
            SdkError = -1,
            Undone = 0,
            InProgress = 1,
            DoneSuccess = 2,
            DoneFatalError = 3,
            DoneMinorError = 4,
            CurrentTask = 5
        };

        private bool GetResult(String _CommandName)
        {
            bool bExecuteStatus = true;
            int rCode = 0;
            NrkSdk.GetMPStepResult(ref rCode);
            ErrorMsg = _CommandName;

            switch (rCode)
            {
                case -1:
                    bExecuteStatus = false;
                    Object obj = null;
                    if (NrkSdk.GetMPStepMessages(ref obj))
                    {
                        string msg = "";
                        Array msgs = (Array)obj;
                        for (int i = 0; i < msgs.Length; i++)
                        {
                            msg += (String)msgs.GetValue(i);
                            msg += "\n";
                            //Console.WriteLine(msg);
                        }
                        ErrorMsg += ":" + msg;
                    }
                    else
                    {
                        ErrorMsg += ":" + "未指定的错误。";
                    }
                    break;
                case 0:
                    bExecuteStatus = false;
                    ErrorMsg += "Undone";
                    break;
                case 1:
                    bExecuteStatus = false;
                    ErrorMsg += "InProgress";
                    break;
                case 2:
                    bExecuteStatus = true;
                    ErrorMsg += "DoneSuccess";
                    break;
                case 3:
                    bExecuteStatus = false;
                    ErrorMsg += "DoneFatalError";
                    break;
                case 4:
                    bExecuteStatus = false;
                    ErrorMsg += "DoneMinorError";
                    break;
                case 5:
                    bExecuteStatus = false;
                    ErrorMsg += "CurrentTask";
                    break;

                default:
                    ErrorMsg += "UndefinedCode";
                    break;
            }
            return bExecuteStatus;
        }

        //连接SDK
        public bool Connect()
        {
            int Status = 1;
            NrkSdk = new SpatialAnalyzerSDKClass();
            NrkSdk.ConnectEx(("localhost"), Status);
            bool bExStatus = false;

            switch (Status)
            {
                case 1:
                    bExStatus = true;
                    break;
                case 0:
                    bExStatus = true;
                    break;
                case -1:
                    ErrorMsg = ("已有一个SA SDK 客户端连接到SA。");
                    break;
                case -2:
                    ErrorMsg = ("SA 证书无效。");
                    break;
                case -3:
                    ErrorMsg = ("指定SA服务器地址连接失败！请检查SA软件狗是否插好。");
                    break;
                case -4:
                    ErrorMsg = ("其他套接字错误。");
                    break;
                default:
                    ErrorMsg = ("未知的SA-SDK连接错误。");
                    break;
            }
            return bExStatus;
        }

        //从点名称获取点集合/点集以及点名称
        public bool GetPntInfoFromName(string PntInfo, ref string colName, ref string GrpName, ref string PntName)
        {

            int tablocr = PntInfo.IndexOf(("::"));
            if (tablocr != -1)
            {
                colName = PntInfo.Substring(0, tablocr);
                PntName = PntInfo.Substring(tablocr + 2, PntInfo.Count() - (tablocr + 2));
                int tablocr2 = PntName.IndexOf(("::"));
                if (tablocr2 != -1)
                {
                    GrpName = PntName.Substring(0, tablocr2);

                    PntName = PntName.Substring(tablocr2 + 2, PntName.Count() - (tablocr2 + 2));
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }


        public bool NewSAFile()
        {
            String CommandName = "New SA File";
            NrkSdk.SetStep(CommandName);
            bool bSendStatus = NrkSdk.ExecuteStep();
            return GetResult(CommandName);
        }

        public bool OpenSAFile(string FileName)
        {
            String CommandName = "Open SA File";
            NrkSdk.SetStep(CommandName);
            NrkSdk.SetFilePathArg("SA File Name", FileName, false);
            bool bSendStatus = NrkSdk.ExecuteStep();
            return GetResult(CommandName);
        }

        public bool Save()
        {
            String CommandName = "Save";
            NrkSdk.SetStep(CommandName);
            bool bSendStatus = NrkSdk.ExecuteStep();
            return GetResult(CommandName);
        }

        public bool SaveAs(String _sFileName, bool _bAddSeiralNumber, int _iOptionNum = 0)
        {
            NrkSdk.SetStep("Save As...");
            NrkSdk.SetFilePathArg("File Name", _sFileName, false);
            NrkSdk.SetBoolArg("Add Serial Number?", _bAddSeiralNumber);
            NrkSdk.SetIntegerArg("Optional Number", _iOptionNum);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool BackupNow()
        {
            NrkSdk.SetStep("Backup Now");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool OpenTemplateFile(string _sFileName)
        {
            NrkSdk.SetStep("Open Template File");

            NrkSdk.SetFilePathArg("Template File Name", _sFileName, false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }
        public bool ExitMeasurementPlan()
        {
            NrkSdk.SetStep("Exit Measurement Plan");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }
        public bool ShutDownSA()
        {
            NrkSdk.SetStep("Shut Down SA");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }
        public bool RunAnotherProgram(string _sProgramPath, ref int _iProcessExitCode,
            string _sCommandLineArgu = "", bool _bWaitForProgramCompletion = false)
        {
            NrkSdk.SetStep("Run Another Program");
            NrkSdk.SetFilePathArg("Program Path", _sProgramPath, false);
            NrkSdk.SetStringArg("Command Line Arguments (optional)", _sCommandLineArgu);
            NrkSdk.SetBoolArg("Wait For Program Completion", _bWaitForProgramCompletion);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            //Dim value As Integer
            NrkSdk.GetIntegerArg("Process Exit Code", _iProcessExitCode);
            return bExcuteStatus;
        }
        public bool CopyGeneralFile(string _sSourFileName, string _sDestinationFileName, bool _bOverWrite)
        {
            NrkSdk.SetStep("Copy General File");
            NrkSdk.SetFilePathArg("Source File Name", _sSourFileName, false);
            NrkSdk.SetFilePathArg("Destination File Name", _sDestinationFileName, false);
            NrkSdk.SetBoolArg("Overwrite?", _bOverWrite);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool RenameGeneralFile(string _sSourFileName, string _sDestinationFileName, bool _bOverWrite)
        {
            NrkSdk.SetStep("Rename General File");
            NrkSdk.SetFilePathArg("Source File Name", _sSourFileName, false);
            NrkSdk.SetFilePathArg("Destination File Name", _sDestinationFileName, false);
            NrkSdk.SetBoolArg("Overwrite?", _bOverWrite);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool DeleteGeneralFile(string _sFileName)
        {
            NrkSdk.SetStep("Delete General File");
            NrkSdk.SetFilePathArg("File Name", _sFileName, false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //public bool Verify GeneralFileExists()
        //{
        //    NrkSdk.SetStep("Verify General File Exists");
        //    NrkSdk.SetFilePathArg("File Name", "", false);
        //    NrkSdk.NOT_SUPPORTED("Step if File does exist");
        //    NrkSdk.NOT_SUPPORTED("Step if File doesn't exist");
        //    NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool BrowseforFile()
        //{
        //NrkSdk.SetStep("Browse for File")

        // NrkSdk.SetBoolArg("File Open Dialog? (FALSE = Save As Dialog)", false)
        //	NrkSdk.NOT_SUPPORTED("Working Directory (Optional)")
        //	NrkSdk.SetStringArg("File Extension (Optional)", "")
        //	NrkSdk.SetStringArg("Dialog Title (Optional)", "")
        //bool bExcuteStatus = NrkSdk.ExecuteStep( )

        //Dim bValue As Boolean
        //NrkSdk.GetBoolArg("File Selected (FALSE = Cancelled)", bValue)
        //Dim sValue As String
        //NrkSdk.GetStringArg("File Name", sValue)

        //Dim sValue As String
        //NrkSdk.GetStringArg("Path", sValue)

        //Dim sValue As String
        //NrkSdk.GetStringArg("Path with File Name", sValue)
        //return bExcuteStatus;
        //}


        //public bool BrowseforFile()
        //{
        //NrkSdk.SetStep("Browse for File")
        //	NrkSdk.SetBoolArg("File Open Dialog? (FALSE = Save As Dialog)", false)
        //	NrkSdk.NOT_SUPPORTED("Working Directory (Optional)")
        //	NrkSdk.SetStringArg("File Extension (Optional)", "")
        //	NrkSdk.SetStringArg("Dialog Title (Optional)", "")
        //bool bExcuteStatus = NrkSdk.ExecuteStep( )
        //return bExcuteStatus;

        //public bool
        //Dim bValue As Boolean
        //NrkSdk.GetBoolArg("File Selected (FALSE = Cancelled)", bValue)
        //Dim sValue As String
        //NrkSdk.GetStringArg("File Name", sValue)

        //Dim sValue As String
        //NrkSdk.GetStringArg("Path", sValue)

        //Dim sValue As String
        //NrkSdk.GetStringArg("Path with File Name", sValue)

        //NrkSdk.SetStep("Find Files in Directory")
        //	NrkSdk.SetStringArg("Directory", "")
        //	NrkSdk.SetStringArg("File Name Pattern", "*.*")
        //	NrkSdk.SetBoolArg("Recursive?", false)
        //bool bExcuteStatus = NrkSdk.ExecuteStep( )
        //Dim stringList As Object
        //NrkSdk.GetStringRefListArg("Files", stringList)
        //return bExcuteStatus;
        //}

        //public bool GetDirectoryandFilenamefromPath()
        //{
        //NrkSdk.SetStep("Get Directory and Filename from Path")
        //	NrkSdk.SetStringArg("Path", "")
        //bool bExcuteStatus = NrkSdk.ExecuteStep( )
        //return bExcuteStatus;
        //public bool
        //Dim sValue As String
        //NrkSdk.GetStringArg("Directory", sValue)
        //Dim sValue As String
        //NrkSdk.GetStringArg("Filename", sValue)
        //}

        public bool ImportSAFile(string _FileName, bool _bAllowOperatorSelections)
        {
            NrkSdk.SetStep("Import SA File");
            NrkSdk.SetFilePathArg("SA File Name", _FileName, false);
            NrkSdk.SetBoolArg("Allow Operator Selections", _bAllowOperatorSelections);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ImportASCII(string _sASCIIFilePath, string _sFileFormat, string _sFormat,
           string _sCollectName, string _sObjectName
           )
        {
            NrkSdk.SetStep("Import ASCII: Predefined Formats");
            NrkSdk.SetFilePathArg("ASCII File Path", _sASCIIFilePath, false);
            // Available options: 
            // "X Y Z", "X Y Z Offset [Offset2]", "X Y Z I J K (平面或矢量)", "点名 X Y Z", "点名 X Y Z 偏移量 [偏移量2]", 
            // "矢量名  X Y Z I J K", "点名 X Y Z Ux Uy Uz (1 sigma)", "点组名 点名 X Y Z Ux Uy Uz (1 sigma)", "点名 X Y Z 点组名", "点名 Y X Z 点组名", 
            // "点组名 点名 X Y Z", "集合 点组 X Y Z", "点组名 点名  X Y Z 偏移量 [偏移量2]", "矢量组名 矢量名 X Y Z I J K", "矢量名 X Y Z dX dY dZ SignedMag(可选)", 
            // "VectorGroupName VectorName X Y Z dX dY dZ SignedMag(optional)", "平面名 X Y Z dX dY dZ 平面大小(可选)", "坐标系名 X Y Z  Rx Ry Rz", "PointName Radius Theta(deg) Phi(deg) (polar or spheric)", "PointName Radius Theta(deg) Z (cylindric)", 
            // "点名 X Y Z Tx Ty Tz Td (点公差)", "点名 X Y Z THx TLx THy TLy THz TLz THd TLd (点公差)", "点名 X Y Z Wx Wy Wz [Wmag]", 
            NrkSdk.SetAsciiFileFormatArg("File Format", _sFileFormat);
            // Available options: 
            // "米", "厘米", "毫米", "英尺", "英寸", 
            NrkSdk.SetDistanceUnitsArg("Units", _sFormat);
            NrkSdk.SetCollectionObjectNameArg("Group Name", _sCollectName, _sObjectName);
            NrkSdk.SetBoolArg("Import as Cloud", false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ImportSTEPFile(string _sFilePath)
        {
            NrkSdk.SetStep("Import STEP File");
            NrkSdk.SetFilePathArg("STEP File Path", _sFilePath, false);
            NrkSdk.SetBoolArg("Display Entity Filters", false);
            NrkSdk.SetBoolArg("Display Residuals", false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ImportIGESFile(string _sFilePath)
        {
            NrkSdk.SetStep("Import IGES File");
            NrkSdk.SetFilePathArg("IGES File Path", _sFilePath, false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ImportVDAFile(string _sFilePath)
        {
            NrkSdk.SetStep("Import VDA/FS File");
            NrkSdk.SetFilePathArg("VDA/FS File Path", _sFilePath, false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ImportSATFile(string _sFilePath)
        {
            NrkSdk.SetStep("Import SAT File");
            NrkSdk.SetFilePathArg("SAT File Path", _sFilePath, false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ImportFileAsEmbeddedFile(string _sFilePath, bool _bReplaceExisting)
        {
            NrkSdk.SetStep("Import File as Embedded File");
            NrkSdk.SetFilePathArg("External File Name", _sFilePath, false);
            NrkSdk.SetBoolArg("Replace Existing?", _bReplaceExisting);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ImportMPFileAsEmbeddedMP(string _sFilePath, bool _bReplaceExisting)
        {
            NrkSdk.SetStep("Import MP File as Embedded MP");
            NrkSdk.SetFilePathArg("External MP File Name", _sFilePath, false);
            NrkSdk.SetBoolArg("Replace Existing?", _bReplaceExisting);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool DirectCADAccess(ref bool _bHasWarning, ref string _sWaringMessage,
            ref double ExMinx, ref double ExMiny, ref double ExMinz,
            ref double ExMaxx, ref double ExMaxy, ref double ExMaxz)
        {
            NrkSdk.SetStep("Direct CAD Access");
            NrkSdk.SetFilePathArg("CAD File Name", "", false);
            NrkSdk.SetBoolArg("Import Solids", true);
            NrkSdk.SetBoolArg("Import Surfaces", true);
            NrkSdk.SetBoolArg("Import Polygonized Surfaces", true);
            NrkSdk.SetBoolArg("Import Annotations", true);
            NrkSdk.SetBoolArg("Import Vectors", true);
            NrkSdk.SetBoolArg("Import Points", true);
            NrkSdk.SetStringArg("Point Group Name", "CAD pts");
            NrkSdk.SetBoolArg("Import Attributes/Metadata", true);
            NrkSdk.SetBoolArg("Import Cooordinate Frames", true);
            NrkSdk.SetBoolArg("Import Planes", true);
            NrkSdk.SetBoolArg("Import 3D Curves - Lines", true);
            NrkSdk.SetBoolArg("Import 3D Curves - Circles", true);
            NrkSdk.SetBoolArg("Import 3D Curves - General Curves", true);
            NrkSdk.SetBoolArg("Import Construction Geometry", false);
            NrkSdk.SetBoolArg("Import Hidden Entities", false);
            NrkSdk.SetBoolArg("Import all Surfaces as Mesh Graphical Entities", false);
            NrkSdk.SetBoolArg("Do Not Import Fillets", false);
            NrkSdk.SetBoolArg("Do Not Import Dittos", false);
            NrkSdk.SetIntegerArg("Ditto Threshold", 1);
            NrkSdk.SetBoolArg("Center View on Imported Objects", true);
            NrkSdk.SetBoolArg("Import into Folders matching CAD file hierarchy", false);
            NrkSdk.SetBoolArg("Remove Empty Folders", true);
            NrkSdk.SetIntegerArg("Surface Normals Mode (1 or 2)", 1);
            NrkSdk.SetBoolArg("Prompt on Missing Components", true);
            NrkSdk.SetBoolArg("Selective Import", false);
            NrkSdk.SetStringArg("CAD File Units (leave blank to use the units specified in the file)", "");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetBoolArg("Import Warnings", _bHasWarning);
            NrkSdk.GetStringArg("Import Warning Messages", _sWaringMessage);
            NrkSdk.GetVectorArg("Extents Min", ExMinx, ExMiny, ExMinz);
            NrkSdk.GetVectorArg("Extents Max", ExMaxx, ExMaxy, ExMaxz);

            return bExcuteStatus;
        }

        public bool ImportSAWindowsPlacement(string _sFilePath)
        {
            NrkSdk.SetStep("Import SA Windows Placement");
            NrkSdk.SetFilePathArg("File Path", _sFilePath, false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ImportVSTARSxyzFile(string _sFilePath)
        {
            NrkSdk.SetStep("Import VSTARS .xyz File");
            NrkSdk.SetFilePathArg("File Path", _sFilePath, false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ImportVSTARSCameras(string _sFilePath)
        {
            NrkSdk.SetStep("Import VSTARS Cameras");
            NrkSdk.SetFilePathArg("File Path", _sFilePath, false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool ImportLeicaGSIFile(string _sInsCollect, int InsID, string _sCollectName, string _sObjName, string _sFilePath)
        {
            NrkSdk.SetStep("Import Leica GSI File");
            NrkSdk.SetColInstIdArg("Instrument ID", _sInsCollect, InsID);
            NrkSdk.SetCollectionObjectNameArg("Group Name", _sCollectName, _sObjName);
            NrkSdk.SetFilePathArg("File Path", _sFilePath, false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        //public bool ExportASCIIPoints(string _sFilePath)
        //{
        //    NrkSdk.SetStep("Export ASCII Points");
        //    NrkSdk.SetFilePathArg("ASCII File Path", _sFilePath, false);
        //    CStringArray grpNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionGroupNameRefListArgHelper("Group Names to export", grpNameList);
        //    // Available options: 
        //    // "Space", "Comma", "Tab", 
        //    NrkSdk.SetExportDataDelimeterTypeArg("Data Delimiter", "");
        //    // Available options: 
        //    // "Collection Group Target", "Group Target", "Target", "None", 
        //    NrkSdk.SetExportTargetNameFormatArg("Target Name Format", "");
        //    // Available options: 
        //    // "Cartesian", "Cylindric", "Polar", 
        //    NrkSdk.SetCoordinateSystemTypeArg("Desired Coordinate System", "");
        //    NrkSdk.SetBoolArg("Include Target Offsets?", FALSE);
        //    NrkSdk.SetBoolArg("Include Target Comments?", FALSE);
        //    NrkSdk.SetBoolArg("Include Timestamps?", FALSE);
        //    NrkSdk.SetBoolArg("Include Tolerances?", FALSE);
        //    NrkSdk.SetBoolArg("Include Coordinate Uncertainties?", FALSE);
        //    NrkSdk.SetBoolArg("Include SA version and frame comments?", FALSE);
        //    NrkSdk.SetBoolArg("Include Axis Comments?", FALSE);
        //    NrkSdk.SetBoolArg("Include Measurement Details?", FALSE);
        //    NrkSdk.SetBoolArg("Maximum Precision (Scientific Notation)?", FALSE);
        //    NrkSdk.SetIntegerArg("Decimal Precision", 6);
        //    NrkSdk.SetBoolArg("Append?", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //    public bool (){
        //NrkSdk.SetStep("Export ASCII Point Clouds");
        //	NrkSdk.SetFilePathArg("ASCII File Path", "", FALSE);
        //	CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Point Cloud List", objNameList);
        //	// Available options: 
        //	// "Space", "Comma", "Tab", 
        //	NrkSdk.SetExportDataDelimeterTypeArg("Data Delimiter", "");
        //	NrkSdk.SetBoolArg("Overwrite existing file?", FALSE);
        //	NrkSdk.SetBoolArg("Show Progress Dialog?", TRUE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}
        //public bool (){
        //             }

        //    public bool (){
        //NrkSdk.SetStep("Export Vector Container to Excel File");
        //	NrkSdk.SetFilePathArg("Excel File Path", "", FALSE);
        //	NrkSdk.SetCollectionObjectNameArg("Vector group to export", "", "");
        //	NrkSdk.SetBoolArg("Overwrite existing file?", FALSE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;} public bool (){
        //             }

        //    public bool (){
        //NrkSdk.SetStep("Export Vector Container to ASCII File");
        //	NrkSdk.SetFilePathArg("Ascii File Path", "", FALSE);
        //	NrkSdk.SetCollectionObjectNameArg("Vector group to export", "", "");
        //	NrkSdk.SetBoolArg("Overwrite existing file?", TRUE);
        //	NrkSdk.SetBoolArg("Use Full Precision (Scientific Notation)?", FALSE);
        //	// Available options: 
        //	// "Collection Group Vector", "Group Vector", "Vector", "None", 
        //	NrkSdk.SetExportVectorNameFormatArg("Vector Name Format", "Vector");
        //	NrkSdk.SetBoolArg("Include Length?", TRUE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;} public bool (){
        //             }

        //    public bool (){
        //NrkSdk.SetStep("Export STEP File - Entire Model");
        //	NrkSdk.SetFilePathArg("STEP File Path", "", FALSE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;} public bool (){
        //             }

        //    public bool (){
        //NrkSdk.SetStep("Export STEP File - Partial Model");
        //	NrkSdk.SetFilePathArg("STEP File Path", "", FALSE);
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("Object Name List", objNameList);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;} public bool (){
        //             }

        //    public bool (){
        //NrkSdk.SetStep("Export IGES File  - Entire Model");
        //	NrkSdk.SetFilePathArg("IGES File Path", "", FALSE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;} public bool (){
        //             }

        //    public bool (){
        //NrkSdk.SetStep("Export IGES File - Partial Model");
        //	NrkSdk.SetFilePathArg("IGES File Path", "", FALSE);
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("Object Name List", objNameList);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;} public bool (){
        //             }

        //    public bool (){
        //NrkSdk.SetStep("Export VDA/FS File  - Entire Model");
        //	NrkSdk.SetFilePathArg("VDA/FS File Path", "", FALSE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;} public bool (){
        //             }

        //    public bool (){ 
        //NrkSdk.SetStep("Export VDA/FS File - Partial Model");
        //	NrkSdk.SetFilePathArg("VDA/FS File Path", "", FALSE);
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("Object Name List", objNameList);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;} public bool (){
        //              }

        //    public bool (){
        //NrkSdk.SetStep("Export Embedded File");
        //	NrkSdk.SetCollectionNameArg("Embedded File Collection Name", "");
        //	NrkSdk.SetStringArg("Embedded File Name", "");
        //	NrkSdk.SetFilePathArg("External File Name", "", FALSE);
        //	NrkSdk.SetBoolArg("Replace Existing?", FALSE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;} public bool (){
        //              }

        //    public bool (){
        //NrkSdk.SetStep("Export DXF");
        //	NrkSdk.SetFilePathArg("DXF File Path", "", FALSE);
        //	CStringArray ptNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetPointNameRefListArgHelper("Point Names", ptNameList);
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("Cloud Names", objNameList);
        //	NrkSdk.SetBoolArg("Include Point Labels?", TRUE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;} public bool (){
        //              }

        public bool OpenASCIIFile(string _sFilePath, ref int iASCIIFileHandle, ref int iASCIIFileSize)
        {
            NrkSdk.SetStep("Open ASCII File");
            NrkSdk.SetFilePathArg("ASCII File Path", _sFilePath, false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetIntegerArg("ASCII File Handle", iASCIIFileHandle);
            NrkSdk.GetIntegerArg("ASCII File Size (Lines)", iASCIIFileSize);
            return bExcuteStatus;
        }

        public bool WriteASCIILine(int _iASCIIFileHandle, bool _bMakeCSVRow)
        {
            NrkSdk.SetStep("Write ASCII Line");
            NrkSdk.SetIntegerArg("ASCII File Handle", _iASCIIFileHandle);
            NrkSdk.SetBoolArg("MakeCSVRow", _bMakeCSVRow);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool CloseASCIIFile(int _iASCIIFileHandle, bool _bSave)
        {
            NrkSdk.SetStep("Close ASCII File");
            NrkSdk.SetIntegerArg("ASCII File Handle", _iASCIIFileHandle);
            NrkSdk.SetBoolArg("Save?", _bSave);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool LoadDataShareFile(string _sFilePath)
        {
            NrkSdk.SetStep("Load DataShare File");
            NrkSdk.SetFilePathArg("DataShare File Path", _sFilePath, false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SaveDataShareFile(string _sFilePath, bool _bBinaryFormat, bool _bAppend)
        {
            NrkSdk.SetStep("Save DataShare File");
            NrkSdk.SetFilePathArg("DataShare File Path", _sFilePath, false);
            NrkSdk.SetBoolArg("Save in Binary Format?", _bBinaryFormat);
            NrkSdk.SetBoolArg("Append to existing file?", _bAppend);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool GetIntegerFromDataShareFile(string _sFilePath, string _sIntegerName, ref int _iIntValue)
        {
            NrkSdk.SetStep("Get Integer From DataShare File");
            NrkSdk.SetFilePathArg("DataShare File Path", _sFilePath, false);
            NrkSdk.SetStringArg("Integer Name", _sIntegerName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetIntegerArg("Integer Value", _iIntValue);
            return bExcuteStatus;
        }

        public bool GetDoubleFromDataShareFile(string _sFilePath, string _sDoubleName, ref double _iDoubleValue)
        {
            NrkSdk.SetStep("Get Double From DataShare File");
            NrkSdk.SetFilePathArg("DataShare File Path", _sFilePath, false);
            NrkSdk.SetStringArg("Double Name", _sDoubleName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetDoubleArg("Double Value", _iDoubleValue);
            return bExcuteStatus;
        }

        public bool GetStringFromDataShareFile(string _sFilePath, string _sStringName, ref string _sStringValue)
        {
            NrkSdk.SetStep("Get String From DataShare File");
            NrkSdk.SetFilePathArg("DataShare File Path", _sFilePath, false);
            NrkSdk.SetStringArg("String Name", _sStringName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetStringArg("String Value", _sStringValue);
            return bExcuteStatus;
        }

        public bool GetVectorFromDataShareFile(string _sFilePath, string _sVectorName,
            ref double _dVecX, ref double _dVecY, ref double _dVecZ)
        {
            NrkSdk.SetStep("Get Vector From DataShare File");
            NrkSdk.SetFilePathArg("DataShare File Path", _sFilePath, false);
            NrkSdk.SetStringArg("Vector Name", _sVectorName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetVectorArg("Vector Value", _dVecX, _dVecY, _dVecZ);
            return bExcuteStatus;
        }
        public bool GetTransformFromDataShareFile(string _sFilePath, string _sTransformName, object _Transform)
        {
            NrkSdk.SetStep("Get Transform From DataShare File");
            NrkSdk.SetFilePathArg("DataShare File Path", _sFilePath, false);
            NrkSdk.SetStringArg("Transform Name", _sTransformName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetTransformArg("Transform Value", _Transform);
            return bExcuteStatus;
        }

        public bool SetIntegerInDataShareFile(string _sFilePath, string _sIntName, int _iValue)
        {
            NrkSdk.SetStep("Set Integer In DataShare File");
            NrkSdk.SetFilePathArg("DataShare File Path", _sFilePath, false);
            NrkSdk.SetStringArg("Integer Name", _sIntName);
            NrkSdk.SetIntegerArg("Integer Value", _iValue);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }
        public bool SetDoubleInDataShareFile(string _sFilePath, string _sDoubleName, double _dDoubleValue)
        {
            NrkSdk.SetStep("Set Double In DataShare File");
            NrkSdk.SetFilePathArg("DataShare File Path", _sFilePath, false);
            NrkSdk.SetStringArg("Double Name", _sDoubleName);
            NrkSdk.SetDoubleArg("Double Value", _dDoubleValue);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }
        public bool SetStringInDataShareFile(string _sFilePath, string _sStringName, string _sStringValue)
        {
            NrkSdk.SetStep("Set String In DataShare File");
            NrkSdk.SetFilePathArg("DataShare File Path", _sFilePath, false);
            NrkSdk.SetStringArg("String Name", _sStringName);
            NrkSdk.SetStringArg("String Value", _sStringValue);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetVectorInDataShareFile(string _sFilePath, string _sVectorName,
            double _dXVal, double _dYVal, double _dZVal)
        {
            NrkSdk.SetStep("Set Vector In DataShare File");
            NrkSdk.SetFilePathArg("DataShare File Path", _sFilePath, false);
            NrkSdk.SetStringArg("Vector Name", _sVectorName);
            NrkSdk.SetVectorArg("Vector Value", _dXVal, _dYVal, _dZVal);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //需测试
        public bool SetTransformInDataShareFile(string _sFilePath, string _sTransformName, double[,] _dTransform)
        {
            NrkSdk.SetStep("Set Transform In DataShare File");
            NrkSdk.SetFilePathArg("DataShare File Path", _sFilePath, false);
            NrkSdk.SetStringArg("Transform Name", _sTransformName);
            NrkSdk.SetTransformArg("Transform Value", _dTransform);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool PutToODBCDatabase(string _sConnectString, string TableName)
        {
            NrkSdk.SetStep("Put to ODBC Database");
            NrkSdk.SetStringArg("Connection String", _sConnectString);
            NrkSdk.SetStringArg("Table Name", TableName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool GetFromODBCDatabase(string _sConnectString, string TableName, string _sWhere)
        {
            NrkSdk.SetStep("Get from ODBC Database");
            NrkSdk.SetStringArg("Connection String", _sConnectString);
            NrkSdk.SetStringArg("Table Name", TableName);
            NrkSdk.SetStringArg("WHERE", _sWhere);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool DeleteFromODBCDatabase(string _sConnectString, string _sTableName, string _sWhere)
        {
            NrkSdk.SetStep("Delete from ODBC Database");
            NrkSdk.SetStringArg("Connection String", _sConnectString);
            NrkSdk.SetStringArg("Table Name", _sTableName);
            NrkSdk.SetStringArg("WHERE", _sWhere);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool OpenXMLFile(string _sFilePath, ref int _iXMLFileHandle)
        {
            NrkSdk.SetStep("Open XML File");
            NrkSdk.SetFilePathArg("XML File Path", _sFilePath, false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetIntegerArg("XML File Handle", _iXMLFileHandle);
            return bExcuteStatus;
        }

        public bool GetXMLAttribute(int _iXMLFileHandle, string _sXPath)
        {
            NrkSdk.SetStep("Get XML Attribute");
            NrkSdk.SetIntegerArg("XML File Handle", _iXMLFileHandle);
            NrkSdk.SetStringArg("XPath", _sXPath);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetXMLAttribute(int _iXMLFileHandle, string _sXPath)
        {
            NrkSdk.SetStep("Set XML Attribute");
            NrkSdk.SetIntegerArg("XML File Handle", _iXMLFileHandle);
            NrkSdk.SetStringArg("XPath", _sXPath);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool CloseXMLFile(int _iXMLFileHandle, bool _bSave)
        {
            NrkSdk.SetStep("Close XML File");
            NrkSdk.SetIntegerArg("XML File Handle", _iXMLFileHandle);
            NrkSdk.SetBoolArg("Save?", _bSave);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }
        public bool ImportNominalsFromXMLFile(string _sFilePath)
        {
            NrkSdk.SetStep("Import Nominals from XML File");
            NrkSdk.SetFilePathArg("File Path", _sFilePath, false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool MergeMeasurementsIntoXMLFile(string _sFilePath, string _sCollectionName, string _sObjName)
        {
            NrkSdk.SetStep("Merge Measurements into XML File");
            NrkSdk.SetFilePathArg("File Path", _sFilePath, false);
            NrkSdk.SetCollectionObjectNameArg("Group Name", _sCollectionName, _sObjName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }
        public bool CreateClearTaskOverviewList()
        {
            NrkSdk.SetStep("Create/Clear Task Overview List");
            NrkSdk.SetFontTypeArg("Task Name Font", "SimSun", 9, 0, 0, 0);
            NrkSdk.SetFontTypeArg("Task Comment Font", "SimSun", 9, 0, 0, 0);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetOverviewTitle(string _sOverviewTitle)
        {
            NrkSdk.SetStep("Set Overview Title");
            NrkSdk.SetStringArg("Overview Title", _sOverviewTitle);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetOverviewImage(string _sImagePath)
        {
            NrkSdk.SetStep("Set Overview Image");
            NrkSdk.SetFilePathArg("Image Path", _sImagePath, false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool AddTaskOverviewItem(string _sTaskName, string _sCommantText, double _dEffortIndex)
        {
            NrkSdk.SetStep("Add Task Overview Item");
            NrkSdk.SetStringArg("Task Name", _sTaskName);
            NrkSdk.SetStringArg("Comment Text", _sCommantText);
            NrkSdk.SetDoubleArg("Effort Index", _dEffortIndex);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        //        public bool SetTaskItemStatus(int _iTaskIndex,)
        //        {
        //NrkSdk.SetStep("Set Task Item Status");
        //	NrkSdk.SetIntegerArg("Task Index", 0);
        //	NrkSdk.NOT_SUPPORTED("Status");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        public bool SetTaskItemComment(int _iTaskIndex, string _sTaskComment)
        {
            NrkSdk.SetStep("Set Task Item Comment");
            NrkSdk.SetIntegerArg("Task Index", _iTaskIndex);
            NrkSdk.SetStringArg("Task Comment", _sTaskComment);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetTaskItemName(int _iTaskIndex, string _sTaskName)
        {
            NrkSdk.SetStep("Set Task Item Name");
            NrkSdk.SetIntegerArg("Task Item Index", _iTaskIndex);
            NrkSdk.SetStringArg("Task Name", _sTaskName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ShowProgressForTaskItem(int _iTaskIndex, bool _bShowProgress)
        {
            NrkSdk.SetStep("Show Progress for Task Item");
            NrkSdk.SetIntegerArg("Task Index", _iTaskIndex);
            NrkSdk.SetBoolArg("Show Progress?", _bShowProgress);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetTaskItemCompletionValues(int _iTaskIndex, int _iIncrementsCompleted, int _iTotalIncrements)
        {
            NrkSdk.SetStep("Set Task Item Completion Values");
            NrkSdk.SetIntegerArg("Task Index", _iTaskIndex);
            NrkSdk.SetIntegerArg("Increments Completed", _iIncrementsCompleted);
            NrkSdk.SetIntegerArg("Total Increments", _iTotalIncrements);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetCurrentTask(int _iTaskIndex)
        {
            NrkSdk.SetStep("Set Current Task");
            NrkSdk.SetIntegerArg("Task Index", _iTaskIndex);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ShowTaskOverviewList(bool _bShow)
        {
            NrkSdk.SetStep("Show Task Overview List");
            NrkSdk.SetBoolArg("Show?", _bShow);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool RunSubroutine(string _sSubroutineFilePath, bool _bShareParentVariables)
        {
            NrkSdk.SetStep("Run Subroutine");
            NrkSdk.SetFilePathArg("MP Subroutine File Path", _sSubroutineFilePath, false);
            NrkSdk.SetBoolArg("Share Parent Variables?", _bShareParentVariables);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool DefineSubroutineInputValues()
        {
            NrkSdk.SetStep("Define Subroutine Input Values");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ReturnFromSubroutineNow(string _sObjectName)
        {
            NrkSdk.SetStep("Return from Subroutine Now");
            NrkSdk.SetResultArg("MP Subroutine Return Step Result", _sObjectName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool DefineSubroutineReturnValues(string _sObjectName)
        {
            NrkSdk.SetStep("Define Subroutine Return Values");
            NrkSdk.SetResultArg("MP Subroutine Return Step Result", _sObjectName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool AutoScale()
        {
            NrkSdk.SetStep("Auto-Scale");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ShowLabels(bool _bPointLabelsOn, bool _bObjectLabelsOn)
        {
            NrkSdk.SetStep("Show Labels");
            NrkSdk.SetBoolArg("Point Labels On?", _bPointLabelsOn);
            NrkSdk.SetBoolArg("Objects Labels On?", _bObjectLabelsOn);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetTargetLabelsUseFullNames(bool _bUseFullName)
        {
            NrkSdk.SetStep("Set Target Labels Use Full Names");
            NrkSdk.SetBoolArg("Use Full Names?", _bUseFullName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetRenderModeType(string _sRenderingMode)
        {
            NrkSdk.SetStep("Set Render Mode Type");
            // Available options: 
            // "Wireframe", "Hidden Line Removed", "Solid+Edges", "Solid", 
            NrkSdk.SetRenderModeTypeArg("Rendering Mode", _sRenderingMode);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetPointOfViewFromFrame(string _sCollectionName, string _sObjName)
        {
            NrkSdk.SetStep("Set Point of View from Frame");
            NrkSdk.SetCollectionObjectNameArg("Frame", _sCollectionName, _sObjName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetViewClippingPlane(string _sCollectionName, string _sObjName, bool _bRemaveClippingPlane)
        {
            NrkSdk.SetStep("Set View Clipping Plane");
            NrkSdk.SetCollectionObjectNameArg("Object", _sCollectionName, _sObjName);
            NrkSdk.SetBoolArg("Remove Clipping Plane?", _bRemaveClippingPlane);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetPointOfView(string _sViewName)
        {
            NrkSdk.SetStep("Set point of view");
            NrkSdk.SetViewNameArg("View Name", _sViewName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SavePointOfView(string _sViewName, bool _bRestoreZoomSetting)
        {
            NrkSdk.SetStep("Save point of view");
            NrkSdk.SetViewNameArg("View Name", _sViewName);
            NrkSdk.SetBoolArg("Restore Zoom Settings?", _bRestoreZoomSetting);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool DefinePointOfView(string _sViewName, double _dRx, double _dRy, double _dRz, bool _bRestoreZoomSettings,
            double _dScaleFactor, int _iOriX, int _iOriY, bool _bRestoreRenderMode, string _sRanderingMode)
        {
            NrkSdk.SetStep("Define point of view");
            NrkSdk.SetViewNameArg("View Name", _sViewName);
            NrkSdk.SetDoubleArg("Rotation (x)", _dRx);
            NrkSdk.SetDoubleArg("Rotation (y)", _dRy);
            NrkSdk.SetDoubleArg("Rotation (z)", _dRz);
            NrkSdk.SetBoolArg("Restore Zoom Settings?", _bRestoreZoomSettings);
            NrkSdk.SetDoubleArg("Scale Factor", _dScaleFactor);
            NrkSdk.SetIntegerArg("Origin (x)", _iOriX);
            NrkSdk.SetIntegerArg("Origin (y)", _iOriY);
            NrkSdk.SetBoolArg("Restore Render Mode?", _bRestoreRenderMode);
            // Available options: 
            // "Wireframe", "Hidden Line Removed", "Solid+Edges", "Solid", 
            NrkSdk.SetRenderModeTypeArg("Rendering Mode", _sRanderingMode);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool GetPointOfViewParameters(string _sViewName, ref double _dRx, ref double _dRy, ref double _dRz, ref bool _bRestoreZoomSettings,
            ref double _dScaleFactor, ref int _iOriX, ref int _iOriY, ref bool _bRestoreRenderMode)
        {
            NrkSdk.SetStep("Get point of view parameters");
            NrkSdk.SetViewNameArg("View Name", _sViewName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetDoubleArg("Rotation (x)", _dRx);
            NrkSdk.GetDoubleArg("Rotation (y)", _dRy);
            NrkSdk.GetDoubleArg("Rotation (z)", _dRz);
            NrkSdk.GetBoolArg("Restore Zoom Settings?", _bRestoreZoomSettings);
            NrkSdk.GetDoubleArg("Scale Factor", _dScaleFactor);
            NrkSdk.GetIntegerArg("Origin (x)", _iOriX);
            NrkSdk.GetIntegerArg("Origin (y)", _iOriY);
            NrkSdk.GetBoolArg("Restore Render Mode?", _bRestoreRenderMode);
            return bExcuteStatus;
        }

        public bool HideObjects(ref object _ObjectList)
        {
            NrkSdk.SetStep("Hide Objects");
            NrkSdk.SetCollectionObjectNameRefListArg("Objects To Hide", _ObjectList);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ShowHideByObjectType(bool _bAllCollections, string _sSpecificCollection, string _sObjType, bool _bHide)
        {
            NrkSdk.SetStep("Show / Hide by Object Type");
            NrkSdk.SetBoolArg("All Collections?", _bAllCollections);
            NrkSdk.SetCollectionNameArg("Specific Collection", _sSpecificCollection);
            // Available options: 
            // "Any", "Circle", "Cloud", "Cone", "Curves", 
            // "Cylinder", "Ellipse", "Frame", "Line", "Paraboloid", 
            // "Perimeter", "Plane", "Point Group", "Poly Surface", "Sphere", 
            // "Spline", "Surface", "Vector Group", 
            NrkSdk.SetObjectTypeArg("Object Type To Show / Hide", _sObjType);
            NrkSdk.SetBoolArg("Hide? (Show = FALSE)", _bHide);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ShowHidePoints(ref object _ObjectList, bool _bShow)
        {
            //NrkSdk.SetStep("Show / Hide Points");
            //var[] ptNameList = new var[1];
            //object vPointObjectList = new System.Runtime.InteropServices.VariantWrapper(ptNameList);
            //NrkSdk.SetPointNameRefListArg("Point Names", vPointObjectList);
            //NrkSdk.SetBoolArg("Show? (Hide = FALSE)", false);
            //NrkSdk.ExecuteStep()
            NrkSdk.SetStep("Show / Hide Points");
            NrkSdk.SetPointNameRefListArg("Point Names", _ObjectList);
            NrkSdk.SetBoolArg("Show? (Hide = FALSE)", _bShow);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        //        public bool ShowObjects()
        //        {

        //NrkSdk.SetStep("Show Objects");
        //	CStringArray objNameList;
        //        SDKHelper helper(NrkSdk);
        //        helper.SetCollectionObjectNameRefListArgHelper("Objects To Show", objNameList);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;
        //        }

        public bool ShowByObjectType(string _sCollectName, string _sObjectTypeName, bool _bAllCollections)
        {
            NrkSdk.SetStep("Show by Object Type");
            NrkSdk.SetCollectionObjectNameArg("Object Type To Show", _sCollectName, _sObjectTypeName);
            NrkSdk.SetBoolArg("All Collections?", _bAllCollections);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //        public bool ShowHideInstruments()
        //        {

        //NrkSdk.SetStep("Show/Hide Instruments");
        //	CStringArray instObjList;
        //        SDKHelper helper(NrkSdk);
        //        helper.SetColInstIdRefListArgHelper("Instrument IDs", instObjList);
        //	NrkSdk.SetBoolArg("Show Instruments?", FALSE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        public bool ShowHideInstrumentProbeTip(bool _bShow)
        {
            NrkSdk.SetStep("Show/Hide Instrument Probe Tip");
            NrkSdk.SetBoolArg("Show Instrument Probe Tip?", _bShow);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetSAsWindowState(string _sWindowState)
        {
            NrkSdk.SetStep("Set SA's Window State");
            // Available options: 
            // "Maximize", "Minimize", "Restore", "Show", "Hide", 
            NrkSdk.SetWindowStateArg("SA Window State", _sWindowState);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetSAsWindowPos(int _iPosX, int _iPosY)
        {
            NrkSdk.SetStep("Set SA's Window Pos");
            NrkSdk.SetIntegerArg("Pos X", _iPosX);
            NrkSdk.SetIntegerArg("Pos Y", _iPosY);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetSAsWindowSize(int _iWidth, int _iHeight)
        {
            NrkSdk.SetStep("Set SA's Window Size");
            NrkSdk.SetIntegerArg("Width", 0);
            NrkSdk.SetIntegerArg("Height", 0);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetMPsWindowState(string _sWindowState)
        {
            NrkSdk.SetStep("Set MP's Window State");
            // Available options: 
            // "Maximize", "Minimize", "Restore", "Show", "Hide", 
            NrkSdk.SetWindowStateArg("MP Window State", _sWindowState);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //        public bool ShowHideCalloutView()
        //        {
        //NrkSdk.SetStep("Show / Hide Callout View");
        //	NrkSdk.NOT_SUPPORTED("Callout View To Show");
        //	NrkSdk.SetBoolArg("Show Callout View?", TRUE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        public bool CenterGraphicsAboutPoint(string _sCollectName, string _GroupName, string _PntName)
        {
            NrkSdk.SetStep("Center Graphics About Point");
            NrkSdk.SetPointNameArg("Point Name", _sCollectName, _GroupName, _PntName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool CenterGraphicsAboutObject(string _sObjectType)
        {
            NrkSdk.SetStep("Center Graphics About Object(s)");
            // Available options: 
            // "Any", "Circle", "Cloud", "Cone", "Curves", 
            // "Cylinder", "Ellipse", "Frame", "Line", "Paraboloid", 
            // "Perimeter", "Plane", "Point Group", "Poly Surface", "Sphere", 
            // "Spline", "Surface", "Vector Group", 
            NrkSdk.SetObjectTypeArg("Object Type", _sObjectType);
            NrkSdk.SetStringArg("Collection Wildcard Criteria", "*");
            NrkSdk.SetStringArg("Object Wildcard Criteria", "*");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        //        public bool SetBackgroundColor()
        //        {
        //NrkSdk.SetStep("Set Background Color");
        //	NrkSdk.NOT_SUPPORTED("Background Color Type");
        //	NrkSdk.SetColorArg("Solid Color Name", 255, 0, 0);
        //	NrkSdk.SetColorArg("Gradient Start Color Name", 255, 0, 0);
        //	NrkSdk.SetColorArg("Gradient End Color Name", 255, 0, 0);
        //	NrkSdk.NOT_SUPPORTED("Gradient Color Direction");
        //	NrkSdk.SetColorArg("Highlight Color", 255, 0, 0);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        //    public bool ShowHideAnnotationsForFeatureChecks()
        //        {
        //NrkSdk.SetStep("Show/Hide Annotations for Feature Checks");
        //	NrkSdk.NOT_SUPPORTED("Feature Check Name List");
        //	NrkSdk.SetBoolArg("Show?", FALSE);
        //	NrkSdk.SetBoolArg("Highlight?", FALSE);
        //	NrkSdk.SetBoolArg("Set Inspection View?", FALSE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        //public bool (){

        //NrkSdk.SetStep("Show/Hide Annotations for Datums");
        //	NrkSdk.NOT_SUPPORTED("Datum Name List");
        //	NrkSdk.SetBoolArg("Show?", FALSE);
        //	NrkSdk.SetBoolArg("Highlight?", FALSE);
        //	NrkSdk.SetBoolArg("Set Inspection View?", FALSE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;} 


        public bool CloudDisplayControl(int _iDrawInc, int _iPntSize)
        {
            NrkSdk.SetStep("Cloud Display Control");
            NrkSdk.SetIntegerArg("Thin (Draw Increment)", _iDrawInc);
            NrkSdk.SetIntegerArg("Point Size", _iPntSize);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        //        public bool ShowItemsInTree()
        //        {
        //NrkSdk.SetStep("Show Items in Tree");
        //	NrkSdk.SetBoolArg("Collapse all other Items?", TRUE);
        //	CStringArray ptNameList;
        //        SDKHelper helper(NrkSdk);
        //        helper.SetPointNameRefListArgHelper("Points", ptNameList);
        //	CStringArray objNameList;
        //        SDKHelper helper(NrkSdk);
        //        helper.SetCollectionObjectNameRefListArgHelper("Objects", objNameList);
        //	CStringArray instObjList;
        //        SDKHelper helper(NrkSdk);
        //        helper.SetColInstIdRefListArgHelper("Instruments", instObjList);
        //	NrkSdk.NOT_SUPPORTED("Feature Checks");
        //	NrkSdk.NOT_SUPPORTED("Datums");
        //	CStringArray stringList;
        //        SDKHelper helper(NrkSdk);
        //        helper.SetStringRefListArgHelper("Collections", stringList);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        //    public bool MirrorObject(){
        //NrkSdk.SetStep("Mirror Object(s)");
        //	CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Object(s)", objNameList);
        //	NrkSdk.SetCollectionObjectNameArg("Frame Name", "", "");
        //	NrkSdk.NOT_SUPPORTED("Frame Plane to Mirror Around");
        //	NrkSdk.SetBoolArg("Copy? [FALSE = Move]", TRUE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        public bool CopyObject(string _sSourceCollection, string _sSourceObj,
            string _sNewCollection, string _sNewObj,
            bool _bOverwrite)
        {
            NrkSdk.SetStep("Copy Object");
            NrkSdk.SetCollectionObjectNameArg("Source Object", _sSourceCollection, _sSourceObj);
            NrkSdk.SetCollectionObjectNameArg("New Object Name", _sNewCollection, _sNewObj);
            NrkSdk.SetBoolArg("Overwrite if exists?", _bOverwrite);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //        public bool (){
        //NrkSdk.SetStep("Copy Objects to a collection");
        //	CStringArray objNameList;
        //        SDKHelper helper(NrkSdk);
        //        helper.SetCollectionObjectNameRefListArgHelper("Source Objects", objNameList);
        //	NrkSdk.SetCollectionNameArg("Destination Collection Name", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        //    public bool (){
        //NrkSdk.SetStep("Move Objects to a collection");
        //	CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Source Objects", objNameList);
        //	NrkSdk.SetCollectionNameArg("Destination Collection Name", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        //public bool CopyObjectsPointToPointDelta()
        //        {
        //NrkSdk.SetStep("Copy Objects - Point to Point Delta");
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("Objects to Copy", objNameList);
        //	NrkSdk.SetPointNameArg("First Delta Point", "", "", "");
        //	NrkSdk.SetPointNameArg("Second Delta Point", "", "", "");
        //	NrkSdk.SetCollectionNameArg("Destination Collection Name (Optional)", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();
        //        return bExcuteStatus;
        //}


        //    public bool ()
        //            {
        //NrkSdk.SetStep("Move Objects - Point to Point Delta");
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("Objects to Move", objNameList);
        //	NrkSdk.SetPointNameArg("First Delta Point", "", "", "");
        //	NrkSdk.SetPointNameArg("Second Delta Point", "", "", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        public bool ReNamePoint(string _sOriginalCollection, string _sOriginalGroup, string _sOriginalPnt,
            string _sNewCollection, string _sNewGroup, string _sNewPnt,
            bool _bOverwrite)
        {
            NrkSdk.SetStep("Rename Point");
            NrkSdk.SetPointNameArg("Original Point Name", _sOriginalCollection, _sOriginalGroup, _sOriginalPnt);
            NrkSdk.SetPointNameArg("New Point Name", _sNewCollection, _sNewGroup, _sNewPnt);
            NrkSdk.SetBoolArg("Overwrite if exists?", _bOverwrite);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //        public bool RenamePointsWithNamePattern()
        //        {
        //NrkSdk.SetStep("Rename Points with Name Pattern");
        //	CStringArray ptNameList;
        //        SDKHelper helper(NrkSdk);
        //        helper.SetPointNameRefListArgHelper("Point Names", ptNameList);
        //	NrkSdk.SetStringArg("Name Pattern", "NewName_%d");
        //	NrkSdk.SetIntegerArg("Start Value", 1);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        public bool RenameCollection(string _sOriginalCollection, string _sNewCollection)
        {
            NrkSdk.SetStep("Rename Collection");
            NrkSdk.SetCollectionNameArg("Original Collection Name", _sOriginalCollection);
            NrkSdk.SetCollectionNameArg("New Collection Name", _sNewCollection);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool RenameObject(string _sOriginalCollection, string _sOriginalObj,
            string _sNewCollection, string _sNewObj, bool _bOverwrite)
        {
            NrkSdk.SetStep("Rename Object");
            NrkSdk.SetCollectionObjectNameArg("Original Object Name", _sOriginalCollection, _sOriginalObj);
            NrkSdk.SetCollectionObjectNameArg("New Object Name", _sNewCollection, _sNewObj);
            NrkSdk.SetBoolArg("Overwrite if exists?", _bOverwrite);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool DeletePoints(string[] _ptNameList)
        {
            NrkSdk.SetStep("Delete Points");

            object[] objectArray = Array.ConvertAll(_ptNameList, item => (object)item);
            //object singleObject = objectArray;
            object vPointObjectList = new System.Runtime.InteropServices.VariantWrapper(objectArray);
            NrkSdk.SetPointNameRefListArg("Point Names", vPointObjectList);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        //    public bool Delete Points WildCard Selection(){
        //NrkSdk.SetStep("Delete Points WildCard Selection");
        //	CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Groups to Delete From", objNameList);
        //	NrkSdk.SetPointNameArg("WildCard Selection Names", "", "", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        //public bool (){
        //NrkSdk.SetStep("Construct Objects From Surface Faces - Runtime Select");
        //	NrkSdk.SetBoolArg("Construct Planes?", FALSE);
        //	NrkSdk.SetBoolArg("Construct Cylinders?", FALSE);
        //	NrkSdk.SetBoolArg("Construct Spheres?", FALSE);
        //	NrkSdk.SetBoolArg("Construct Cones?", FALSE);
        //	NrkSdk.SetBoolArg("Construct Lines?", FALSE);
        //	NrkSdk.SetBoolArg("Construct Points?", FALSE);
        //	NrkSdk.SetBoolArg("Construct Circles?", FALSE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        public bool SetDefaultCollection(string _sCollectionName)
        {
            NrkSdk.SetStep("Set (or construct) default collection");
            NrkSdk.SetCollectionNameArg("Collection Name", _sCollectionName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool ConstructCollection(string _sCollectionName, string _sFolderPath, bool _bDefaultCollection)
        {
            NrkSdk.SetStep("Construct Collection");
            NrkSdk.SetCollectionNameArg("Collection Name", _sCollectionName);
            NrkSdk.SetStringArg("Folder Path", _sFolderPath);
            NrkSdk.SetBoolArg("Make Default Collection?", _bDefaultCollection);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool GetActiveCollectionName(string _sActiveCollection)
        {
            NrkSdk.SetStep("Get Active Collection Name");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetCollectionNameArg("Currently Active Collection Name", _sActiveCollection);
            return bExcuteStatus;
        }


        public bool DeleteCollection(string _sCollectionToDelete)
        {
            NrkSdk.SetStep("Delete Collection");
            NrkSdk.SetCollectionNameArg("Name of Collection to Delete", _sCollectionToDelete);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool DeleteCollectionsByWildcard(string _sSearchString, bool _bCaseSensitive, bool _bAllowDeletingAllCollection,
            ref int _iNumDeleted, ref int _iNumFailed)
        {
            NrkSdk.SetStep("Delete Collections by Wildcard");
            NrkSdk.SetStringArg("Search String", _sSearchString);
            NrkSdk.SetBoolArg("Case Sensitive Search", _bCaseSensitive);
            NrkSdk.SetBoolArg("Allow Deleting all Collections", _bAllowDeletingAllCollection);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetIntegerArg("Num Deleted", _iNumDeleted);
            NrkSdk.GetIntegerArg("Num Failed", _iNumFailed);
            return bExcuteStatus;
        }

        //        public bool ConstructPointFitToPoints()
        //        {
        //NrkSdk.SetStep("Construct Point (Fit to Points)");
        //	CStringArray ptNameList;
        //        SDKHelper helper(NrkSdk);
        //        helper.SetPointNameRefListArgHelper("Point Names", ptNameList);
        //	NrkSdk.SetPointNameArg("Resulting Point Name", "", "", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        public bool ConstructAPointInWorkingCoordinates(string _sCollectionName, string _sGroupName, string _sPntName,
            double _dX, double _dY, double _dZ)
        {
            NrkSdk.SetStep("Construct a Point in Working Coordinates");
            NrkSdk.SetPointNameArg("Point Name", _sCollectionName, _sGroupName, _sPntName);
            NrkSdk.SetVectorArg("Working Coordinates", _dX, _dY, _dZ);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructAPointAtLineMidPoint(string _sLineCollectionName, string _sLineName, string _sPntCollection, string _sPntGroup, string _sPntName)
        {
            NrkSdk.SetStep("Construct a Point at line MidPoint");
            NrkSdk.SetCollectionObjectNameArg("Line Name", _sLineCollectionName, _sLineName);
            NrkSdk.SetPointNameArg("Point Name", _sPntCollection, _sPntGroup, _sPntName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //        public bool (){
        //NrkSdk.SetStep("Construct Point Groups from Vector Groups");
        //	CStringArray objNameList;
        //        SDKHelper helper(NrkSdk);
        //        helper.SetCollectionObjectNameRefListArgHelper("Vector Groups", objNameList);
        //	NrkSdk.SetStringArg("Optional Group Name Suffix", "");
        //	NrkSdk.SetBoolArg("Make Vector Begin Points", FALSE);
        //	NrkSdk.SetBoolArg("Make Vector End Points", FALSE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}
        //CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.GetCollectionObjectNameRefListArgHelper("Point Groups", objNameList);

        //    public bool (){
        //NrkSdk.SetStep("Construct Point Group from Point Name Ref List");
        //	CStringArray ptNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetPointNameRefListArgHelper("Point Name List", ptNameList);
        //	NrkSdk.SetCollectionObjectNameArg("Group Name", "", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        //public bool (){
        //NrkSdk.SetStep("Construct Point Group from Point Cloud");
        //	NrkSdk.SetCollectionObjectNameArg("Cloud Name", "", "");
        //	NrkSdk.SetCollectionObjectNameArg("Point Group Name", "", "");
        //	NrkSdk.SetStringArg("Point Prefix", "pt");
        //	NrkSdk.SetIntegerArg("Starting Point Number", 0);
        //	NrkSdk.SetDoubleArg("Point Offset", 0.000000);
        //	NrkSdk.SetBoolArg("Sub-Sampling?", FALSE);
        //	NrkSdk.SetDoubleArg("Sub-Sampling Distance", 0.500000);
        //	NrkSdk.SetBoolArg("Show Progress?", FALSE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        public bool ConstructAPointAtCircleCenter(string _sCircleCollection, string _sCircleName,
            string _sPntCollection, string _sPntGroup, string _sPntName)
        {
            NrkSdk.SetStep("Construct a Point at Circle Center");
            NrkSdk.SetCollectionObjectNameArg("Circle Name", _sCircleCollection, _sCircleName);
            NrkSdk.SetPointNameArg("Point Name", _sPntCollection, _sPntGroup, _sPntName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructPointAtIntersectionOfPlanes(string _sPlane1Collection, string _sPlane1Name,
            string _sPlane2Collection, string _sPlane2Name, string _sPlane3Collection, string _sPlane3Name,
            string _sPntCollection, string _sPntGroup, string _sPntName)
        {
            NrkSdk.SetStep("Construct Point at Intersection of Planes");
            NrkSdk.SetCollectionObjectNameArg("Plane 1 Name", _sPlane1Collection, _sPlane1Name);
            NrkSdk.SetCollectionObjectNameArg("Plane 2 Name", _sPlane2Collection, _sPlane2Name);
            NrkSdk.SetCollectionObjectNameArg("Plane 3 Name", _sPlane3Collection, _sPlane3Name);
            NrkSdk.SetPointNameArg("Point Name", _sPntCollection, _sPntGroup, _sPntName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructPointAtIntersectionOfTwoLines(string _sLine1Collection, string _sLine1Name,
            string _sLine2Collection, string _sLine2Name,
            string _sPntCollection, string _sPntGroup, string _sPntName)
        {
            NrkSdk.SetStep("Construct Point at Intersection of Two Lines");
            NrkSdk.SetCollectionObjectNameArg("First Line Name", _sLine1Collection, _sLine1Name);
            NrkSdk.SetCollectionObjectNameArg("Second Line Name", _sLine2Collection, _sLine2Name);
            NrkSdk.SetPointNameArg("Resulting Point Name", _sPntCollection, _sPntGroup, _sPntName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructPointAtIntersectionOfPlaneAndLine(string _sPlaneCollection, string _sPlaneName,
            string _sLineCollection, string _sLineName,
           string _sPntCollection, string _sPntGroup, string _sPntName)
        {
            NrkSdk.SetStep("Construct Point at Intersection of Plane and Line");
            NrkSdk.SetCollectionObjectNameArg("Plane Name", _sPlaneCollection, _sPlaneName);
            NrkSdk.SetCollectionObjectNameArg("Line Name", _sLineCollection, _sLineName);
            NrkSdk.SetPointNameArg("Resulting Point Name", _sPntCollection, _sPntGroup, _sPntName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructPointAtIntersectionOf2BSplines(string _sBSpline1Collection, string _sBSpline1Name,
            string _sBSpline2Collection, string _sBSpline2Name,
            string _sPntCollection, string _sPntGroup, string _sPntName)
        {
            NrkSdk.SetStep("Construct Point at Intersection of 2 B-Splines");
            NrkSdk.SetCollectionObjectNameArg("First B-Spline Name", _sBSpline1Collection, _sBSpline1Name);
            NrkSdk.SetCollectionObjectNameArg("Second B-Spline Name", _sBSpline2Collection, _sBSpline2Name);
            NrkSdk.SetPointNameArg("Point Name", _sPntCollection, _sPntGroup, _sPntName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        //        public bool ()
        //            {
        //NrkSdk.SetStep("Construct Point at intersection of B-Spline and Surfaces");
        //	NrkSdk.SetCollectionObjectNameArg("B-Spline Name", "", "");
        //	CStringArray objNameList;
        //        SDKHelper helper(NrkSdk);
        //        helper.SetCollectionObjectNameRefListArgHelper("Surface List", objNameList);
        //	NrkSdk.SetDoubleArg("Approximation Tolerance", 0.001000);
        //	NrkSdk.SetPointNameArg("Point Name", "", "", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        public bool ConstructPointsAtIntersectionOfCircleAndLine(string _sCircleCollection, string _sCircleName,
            string _sLineCollection, string _sLineName,
            string _sPntCollection, string _sPntGroup, string _sPntName
            )
        {
            NrkSdk.SetStep("Construct Points at Intersection of Circle and Line");
            NrkSdk.SetCollectionObjectNameArg("Circle Name", _sCircleCollection, _sCircleName);
            NrkSdk.SetCollectionObjectNameArg("Line Name", _sLineCollection, _sLineName);
            NrkSdk.SetPointNameArg("Base Point Name for results", _sPntCollection, _sPntGroup, _sPntName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        //public bool (){
        //NrkSdk.SetStep("Construct Points at Intersection of Principle Object Axes and Surfaces");
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("Axis Object List", objNameList);
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("Surface List", objNameList);
        //	NrkSdk.SetStringArg("Point Suffix (optional)", "");
        //	NrkSdk.SetCollectionObjectNameArg("Resultant Group Name", "", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        //获得圆柱两个中心，及两个中心的连线的中点
        public bool ConstructPointsFromCylinder(string _sCylinderCollection, string _sCylinderName,
            string _sPntCollection, string _sPntGroup)
        {
            NrkSdk.SetStep("Construct Points from Cylinder");
            NrkSdk.SetCollectionObjectNameArg("Cylinder Name", _sCylinderCollection, _sCylinderName);
            NrkSdk.SetCollectionObjectNameArg("Group Name", _sPntCollection, _sPntGroup);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructAPointAtProjectionOfPointOntoAnObject(string _sProjectPntCollection, string _sProjectPntGroup, string _sProjectPntName,
            string _sToProjectObjCollection, string _sToProjectObjName,
            string _sResPntCollection, string _sResPntGroup, string _sResPntName)
        {
            NrkSdk.SetStep("Construct a Point at Projection of Point onto An Object");
            NrkSdk.SetPointNameArg("Point to Project", _sProjectPntCollection, _sProjectPntGroup, _sProjectPntName);
            NrkSdk.SetCollectionObjectNameArg("Object Name", _sToProjectObjCollection, _sToProjectObjName);
            NrkSdk.SetPointNameArg("Resulting Point Name", _sResPntCollection, _sResPntGroup, _sResPntName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        //        public bool ConstructPointsAtProjectionOnSurfacesParallelToWCFAxis()
        //        {
        //NrkSdk.SetStep("Construct Points at Projection on Surfaces - Parallel to WCF Axis");
        //	CStringArray objNameList;
        //        SDKHelper helper(NrkSdk);
        //        helper.SetCollectionObjectNameRefListArgHelper("Surface List", objNameList);
        //	CStringArray ptNameList;
        //        SDKHelper helper(NrkSdk);
        //        helper.SetPointNameRefListArgHelper("Point Names", ptNameList);
        //	NrkSdk.SetStringArg("Group Name to Contain New Points", "");
        //	NrkSdk.SetStringArg("Point Name Prefix", "");
        //	NrkSdk.SetStringArg("Point Name Suffix", "");
        //	NrkSdk.NOT_SUPPORTED("Axis");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        //    public bool (){
        //NrkSdk.SetStep("Construct Points at Projection on Surfaces - Radial from WCF Axis");
        //	CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Surface List", objNameList);
        //	CStringArray ptNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetPointNameRefListArgHelper("Point Names", ptNameList);
        //	NrkSdk.SetStringArg("Group Name to Contain New Points", "");
        //	NrkSdk.SetStringArg("Point Name Prefix", "");
        //	NrkSdk.SetStringArg("Point Name Suffix", "");
        //	NrkSdk.NOT_SUPPORTED("Axis");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        //public bool (){
        //NrkSdk.SetStep("Construct Points at Projection on Surfaces - Spherical from WCF Origin");
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("Surface List", objNameList);
        //	CStringArray ptNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetPointNameRefListArgHelper("Point Names", ptNameList);
        //	NrkSdk.SetStringArg("Group Name to Contain New Points", "");
        //	NrkSdk.SetStringArg("Point Name Prefix", "");
        //	NrkSdk.SetStringArg("Point Name Suffix", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        //        public bool (){
        //NrkSdk.SetStep("Construct Points Spaced at a Distance on Curves");
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("B-Spline List", objNameList);
        //	NrkSdk.SetDoubleArg("Distance Between Points", 0.500000);
        //	NrkSdk.SetCollectionObjectNameArg("Resultant Group Name", "", "");
        //	NrkSdk.SetStringArg("Resultant Point Name Prefix", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        //    public bool (){
        //NrkSdk.SetStep("Construct Points N-Spaced on Curves");
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("B-Spline List", objNameList);
        //	NrkSdk.SetIntegerArg("Number of Evenly Spaced Points", 10);
        //	NrkSdk.SetCollectionObjectNameArg("Resultant Group Name", "", "");
        //	NrkSdk.SetStringArg("Resultant Point Name Prefix", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        //    public bool (){
        //NrkSdk.SetStep("Construct Points on Objects Vertices");
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("Object Name List", objNameList);
        //	NrkSdk.SetCollectionObjectNameArg("Resultant Group Name", "", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        //    public bool (){
        //NrkSdk.SetStep("Construct Points N-Spaced on Curves");
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("B-Spline List", objNameList);
        //	NrkSdk.SetIntegerArg("Number of Evenly Spaced Points", 10);
        //	NrkSdk.SetCollectionObjectNameArg("Resultant Group Name", "", "");
        //	NrkSdk.SetStringArg("Resultant Point Name Prefix", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        //    public bool (){
        //NrkSdk.SetStep("Construct Points N-Spaced on Curves");
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("B-Spline List", objNameList);
        //	NrkSdk.SetIntegerArg("Number of Evenly Spaced Points", 10);
        //	NrkSdk.SetCollectionObjectNameArg("Resultant Group Name", "", "");
        //	NrkSdk.SetStringArg("Resultant Point Name Prefix", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        //    public bool (){
        //NrkSdk.SetStep("Construct Points on Objects Vertices");
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("Object Name List", objNameList);
        //	NrkSdk.SetCollectionObjectNameArg("Resultant Group Name", "", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        //    public bool (){
        //NrkSdk.SetStep("Construct Points on Surface(s) by Clicking");
        //	NrkSdk.SetCollectionObjectNameArg("Group Name for Points", "", "");
        //	NrkSdk.SetStringArg("First Point Name", "p0");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        //    public bool (){
        //NrkSdk.SetStep("Construct Points From Surface Faces - Runtime Select");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        //    public bool (){
        //NrkSdk.SetStep("Construct Point at Object Origin");
        //	NrkSdk.SetCollectionObjectNameArg("Object Name", "", "");
        //	NrkSdk.SetPointNameArg("Resultant Point Name", "", "", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}
        //DOUBLE xVal;
        //DOUBLE yVal;
        //DOUBLE zVal;
        //NrkSdk.GetVectorArg("Vector Representation", &xVal, &yVal, &zVal);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("X Value", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("Y Value", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("Z Value", &value);

        //    public bool (){
        //NrkSdk.SetStep("Construct Points Shifted in Working Frame");
        //	CStringArray ptNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetPointNameRefListArgHelper("Original Points", ptNameList);
        //	NrkSdk.SetCollectionObjectNameArg("Group for New Points", "", "");
        //	NrkSdk.SetVectorArg("Shift Vector", 0.000000, 0.000000, 0.000000);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        //    public bool (){
        //NrkSdk.SetStep("Construct Points Cylindrically Shifted");
        //	NrkSdk.SetCollectionObjectNameArg("Reference Object Name", "", "");
        //	CStringArray ptNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetPointNameRefListArgHelper("Original Points", ptNameList);
        //	NrkSdk.SetCollectionObjectNameArg("Group for New Points", "", "");
        //	NrkSdk.SetDoubleArg("Radial Shift", 0.000000);
        //	NrkSdk.SetDoubleArg("Theta Shift (degrees)", 0.000000);
        //	NrkSdk.SetDoubleArg("Planar Shift", 0.000000);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        //    public bool (){
        //NrkSdk.SetStep("Construct Points WildCard Selection");
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("Groups to Select From", objNameList);
        //	NrkSdk.SetPointNameArg("WildCard Selection Names", "", "", "");
        //	NrkSdk.SetCollectionObjectNameArg("Group for New Points", "", "");
        //	NrkSdk.SetBoolArg("Include prior complete name", FALSE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        //    public bool (){
        //NrkSdk.SetStep("Construct Points Subset with greatest spacing");
        //	CStringArray ptNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetPointNameRefListArgHelper("Points to Subsample", ptNameList);
        //	NrkSdk.SetIntegerArg("Subset Size", 10);
        //	NrkSdk.SetCollectionObjectNameArg("Group for Subset", "", "Spaced Points");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        public bool ConstructPointsLayoutOnGrid(string _sCollectionName, string _sObjName,
            string _sPointPrefix, double _dXmin, double _dXmax, int _iXcount,
            double _dYmin, double _dYmax, int _iYcount,
            double _dZmin, double _dZmax, int _iZcount)
        {
            NrkSdk.SetStep("Construct Points Layout on Grid");
            NrkSdk.SetCollectionObjectNameArg("Group Name", _sCollectionName, _sObjName);
            NrkSdk.SetStringArg("Point Prefix", _sPointPrefix);
            NrkSdk.SetDoubleArg("X Min", _dXmin);
            NrkSdk.SetDoubleArg("X Max", _dXmax);
            NrkSdk.SetIntegerArg("X Count", _iXcount);
            NrkSdk.SetDoubleArg("Y Min", _dYmin);
            NrkSdk.SetDoubleArg("Y Max", _dYmax);
            NrkSdk.SetIntegerArg("Y Count", _iYcount);
            NrkSdk.SetDoubleArg("Z Min", _dZmin);
            NrkSdk.SetDoubleArg("Z Max", _dZmax);
            NrkSdk.SetIntegerArg("Z Count", _iZcount);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructPointsAutoCorrespond2GroupsProximity(string _sRefGroupCollection, string _sRefGroupObj,
            string _sCopyGroupCollection, string _sCopyGroupObj,
            double _dTolerance, string _sGroupCollection, string _sGroupObj)
        {
            NrkSdk.SetStep("Construct Points Auto-Correspond 2 groups Proximity");
            NrkSdk.SetCollectionObjectNameArg("Reference group (known point names)", _sRefGroupCollection, _sRefGroupObj);
            NrkSdk.SetCollectionObjectNameArg("Group to be copied (unknown point names)", _sCopyGroupCollection, _sCopyGroupObj);
            NrkSdk.SetDoubleArg("Auto-correspond same-point tolerance", _dTolerance);
            NrkSdk.SetCollectionObjectNameArg("Group to contain matched points", _sGroupCollection, _sGroupObj);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool ConstructPointsAutoCorrespond2GroupsInterPointDistance(string _sRefGroupCollection, string _sRefGroupObj,
            string _sCopyGroupCollection, string _sCopyGroupObj,
             double _dTolerance, string _sGroupCollection, string _sGroupObj)
        {
            NrkSdk.SetStep("Construct Points Auto-Correspond 2 groups Inter-Point Distance");
            NrkSdk.SetCollectionObjectNameArg("Reference group (known point names)", _sRefGroupCollection, _sRefGroupObj);
            NrkSdk.SetCollectionObjectNameArg("Group to be copied (unknown point names)", _sCopyGroupCollection, _sCopyGroupObj);
            NrkSdk.SetDoubleArg("Auto-correspond same-point tolerance", _dTolerance);
            NrkSdk.SetCollectionObjectNameArg("Group to contain matched points", _sGroupCollection, _sGroupObj);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ExtractSphereCentersFromPointCloud(string _sCloudCollection, string _sCloudName,
            double _dDesireDiameter, double _dTolerance, int _iMinimumPntCount, string _sPntCollection, string _sPntGroupName,
            ref int _iNumberOfPntExtracted)
        {
            NrkSdk.SetStep("Extract Sphere Centers from Point Cloud");
            NrkSdk.SetCollectionObjectNameArg("Cloud Name", _sCloudCollection, _sCloudName);
            NrkSdk.SetDoubleArg("Desired Diameter", _dDesireDiameter);
            NrkSdk.SetDoubleArg("Extraction Tolerance", _dTolerance);
            NrkSdk.SetIntegerArg("Minimum Point Count", _iMinimumPntCount);
            NrkSdk.SetCollectionObjectNameArg("Group Name for Points", _sPntCollection, _sPntGroupName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetIntegerArg("Number of Points Extracted", _iNumberOfPntExtracted);
            return bExcuteStatus;
        }

        public bool CreateHiddenPointRod(double _dA2BDistance, double _dA2CDistansce, double _dA2BInterPntTol,
            ref int _iHiddenPointRodIndex)
        {
            NrkSdk.SetStep("Create Hidden Point Rod");
            NrkSdk.SetDoubleArg("A to B (Target to Target) Distance", _dA2BDistance);
            NrkSdk.SetDoubleArg("A to C (Target to Tip) Distance", _dA2CDistansce);
            NrkSdk.SetDoubleArg("A to B Inter-point Tolerance (0.0 for none)", _dA2BInterPntTol);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetIntegerArg("Hidden Point Rod Index", _iHiddenPointRodIndex);
            return bExcuteStatus;
        }

        public bool CreateHiddenPoint(string _sEndACollection, string _sEndAGroup, string _sEndAPntName,
            string _sEndBCollection, string _sEndBGroup, string _sEndBPneName,
            int _iHiddenPntRodIndex, bool _bOverWriteExist,
             string _sPntCreateCollection, string _sPntCreateGroup, string _sPntCreatePneName)
        {
            NrkSdk.SetStep("Create Hidden Point");
            NrkSdk.SetPointNameArg("End A Point Name", _sEndACollection, _sEndAGroup, _sEndAPntName);
            NrkSdk.SetPointNameArg("End B Point Name", _sEndBCollection, _sEndBGroup, _sEndBPneName);
            NrkSdk.SetIntegerArg("Hidden Point Rod Index", _iHiddenPntRodIndex);
            NrkSdk.SetBoolArg("Overwrite existing point?", _bOverWriteExist);
            NrkSdk.SetPointNameArg("Point Name To Create", _sPntCreateCollection, _sPntCreateGroup, _sPntCreatePneName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //public bool AverageASetOfGroups()
        //{
        //    NrkSdk.SetStep("Average a set of Groups");
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Group Names", objNameList);
        //    NrkSdk.SetCollectionObjectNameArg("Resulting Group Name", "", "");
        //    NrkSdk.SetDoubleArg("RMS Tolerance (0.0 for none)", 0.000000);
        //    NrkSdk.SetDoubleArg("Maximum Absolute Tolerance (0.0 for none)", 0.000000);
        //    NrkSdk.SetDoubleArg("Maximum Average Tolerance (0.0 for none)", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("RMS Deviation", &value);
        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Max Absolute Deviation", &value);
        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Average Deviation", &value);
        //    return bExcuteStatus;
        //}

        //public bool CopyGroupsExcludingObscuredPoints()
        //{
        //    NrkSdk.SetStep("Copy Groups Excluding Obscured Points");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Group Names", objNameList);
        //    NrkSdk.SetCollectionNameArg("New Collection Name", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        public bool ConstructPointCloudsFromExistingPointGroup(string _sPntGroupCollection, string _sPntGroupName,
            string _sCloudCollection, string _sCloudName)
        {
            NrkSdk.SetStep("Construct Point Clouds from Existing Point Group");
            NrkSdk.SetCollectionObjectNameArg("Point Group Name", _sPntGroupCollection, _sPntGroupName);
            NrkSdk.SetCollectionObjectNameArg("Cloud Name", _sCloudCollection, _sCloudName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool ConstructPointCloudsfromExistingCloudPointsRuntimeSelect(string _sCloudCollection, string _sCloudName)
        {
            NrkSdk.SetStep("Construct Point Clouds from Existing Cloud Points - Runtime Select");
            NrkSdk.SetCollectionObjectNameArg("Cloud Name", _sCloudCollection, _sCloudName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //public bool ConstructPointCloudsFromExistingCloudsUniformSpacing()
        //{
        //    NrkSdk.SetStep("Construct Point Clouds from Existing Clouds - Uniform Spacing");
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Existing Point Cloud List", objNameList);
        //    NrkSdk.SetDoubleArg("Desired Point Spacing", 0.000000);
        //    NrkSdk.SetCollectionObjectNameArg("New Cloud Name", "", "");
        //    NrkSdk.SetBoolArg("Hide Original Point Clouds", TRUE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        public bool ConstructScaleBar(string _sScaleBarCollection, string _sScaleBarName,
            string _sBeginTargetCollection, string _sBeginTargetGroup, string _sBeginTargetName,
            string _sEndTargetCollection, string _sEndTargetGroup, string _sEndTargetName,
            double _dLength, double _dUnsertainty)
        {
            NrkSdk.SetStep("Construct Scale Bar");
            NrkSdk.SetCollectionObjectNameArg("Scale Bar Name", _sScaleBarCollection, _sScaleBarName);
            NrkSdk.SetPointNameArg("Begin Target", _sBeginTargetCollection, _sBeginTargetGroup, _sBeginTargetName);
            NrkSdk.SetPointNameArg("End Target", _sEndTargetCollection, _sEndTargetGroup, _sEndTargetName);
            NrkSdk.SetDoubleArg("Length", _dLength);
            NrkSdk.SetDoubleArg("Uncertainty", _dUnsertainty);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructLine2Points(string _sLineCollection, string _sLineName,
            string _sFirstPntCollection, string _sFirstPntGroup, string _sFirstPntName,
            string _sSecondPntCollection, string _sSecondPntGroup, string _sSecondPntName)
        {
            NrkSdk.SetStep("Construct Line 2 Points");
            NrkSdk.SetCollectionObjectNameArg("Line Name", _sLineCollection, _sLineName);
            NrkSdk.SetPointNameArg("First Point", _sFirstPntCollection, _sFirstPntGroup, _sFirstPntName);
            NrkSdk.SetPointNameArg("Second Point", _sSecondPntCollection, _sSecondPntGroup, _sSecondPntName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructLine2PointsVectorNotation(string _sLineCollection, string _sLineName,
            double _dFirstVectorX, double _dFirstVectorY, double _dFirstVectorZ,
            double _dSecondVectorX, double _dSecondVectorY, double _dSecondVectorZ
            )
        {
            NrkSdk.SetStep("Construct Line 2 Points (Vector Notation)");
            NrkSdk.SetCollectionObjectNameArg("Line Name", _sLineCollection, _sLineName);
            NrkSdk.SetVectorArg("First Vector", _dFirstVectorX, _dFirstVectorY, _dFirstVectorZ);
            NrkSdk.SetVectorArg("Second Vector", _dSecondVectorX, _dSecondVectorY, _dSecondVectorZ);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructLineNormalToObject(string _sLineCollection, string _sLineName,
            double _dLineLength, string _sObjectCollection, string _sObjectName)
        {
            NrkSdk.SetStep("Construct Line Normal to Object");
            NrkSdk.SetCollectionObjectNameArg("Line Name", _sLineCollection, _sLineName);
            NrkSdk.SetDoubleArg("Line Length", _dLineLength);
            NrkSdk.SetCollectionObjectNameArg("Object", _sObjectCollection, _sObjectName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructLineProjectLineToObjectReferencePlane(string _sLineToCreateCollection, string _sLineToCreateName,
            string _sLineToProjCollection, string _sLineToProjName,
            string _sObjectToProjToCollection, string _sObjectToProjToName)
        {
            NrkSdk.SetStep("Construct Line - Project Line to Object Reference Plane");
            NrkSdk.SetCollectionObjectNameArg("Line To Create", _sLineToCreateCollection, _sLineToCreateName);
            NrkSdk.SetCollectionObjectNameArg("Line To Project", _sLineToProjCollection, _sLineToProjName);
            NrkSdk.SetCollectionObjectNameArg("Object to project to", _sObjectToProjToCollection, _sObjectToProjToName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructLineNormalToObjectThroughPoint(string _sLineToCreateCollection, string _sLineToCreateName,
            string _sObjectCollection, string _sObjectName,
            string _sPntCollection, string _sPntGroup, string _sPntName)
        {
            NrkSdk.SetStep("Construct Line - Normal to Object through Point");
            NrkSdk.SetCollectionObjectNameArg("Line To Create", _sLineToCreateCollection, _sLineToCreateName);
            NrkSdk.SetCollectionObjectNameArg("Object Name", _sObjectCollection, _sObjectName);
            NrkSdk.SetPointNameArg("Point Name", _sPntCollection, _sPntGroup, _sPntName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructLine2PlaneIntersection(string _sLineCollection, string _sLineName,
            string _sFirstPlaneCollection, string _sFirstPlaneName,
            string _sSecondPlaneCollection, string _sSecondPlaneName)
        {
            NrkSdk.SetStep("Construct Line 2 Plane Intersection");
            NrkSdk.SetCollectionObjectNameArg("Line Name", _sLineCollection, _sLineName);
            NrkSdk.SetCollectionObjectNameArg("First Plane", _sFirstPlaneCollection, _sFirstPlaneName);
            NrkSdk.SetCollectionObjectNameArg("Second Plane", _sSecondPlaneCollection, _sSecondPlaneName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructLinesFromSurfaceFacesRuntimeSelect()
        {
            NrkSdk.SetStep("Construct Lines From Surface Faces - Runtime Select");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructPlane(string _sPlaneCollection, string _sPlaneName,
            double _dPlaneCenterX, double _dPlaneCenterY, double _dPlaneCenterZ,
            double _dPlaneNormalX, double _dPlaneNormalY, double _dPlaneNormalZ,
            double _dPlaneEdgeDimsion)
        {
            NrkSdk.SetStep("Construct Plane");
            NrkSdk.SetCollectionObjectNameArg("Plane Name", _sPlaneCollection, _sPlaneName);
            NrkSdk.SetVectorArg("Plane Center (in working coordinates)", _dPlaneCenterX, _dPlaneCenterY, _dPlaneCenterZ);
            NrkSdk.SetVectorArg("Plane Normal (in working coordinates)", _dPlaneNormalX, _dPlaneNormalY, _dPlaneNormalZ);
            NrkSdk.SetDoubleArg("Plane Edge Dimension", _dPlaneEdgeDimsion);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructPlaneNormalToObjectThroughPoint(string _sResultantPlaneCollection, string _sResultantPlaneName,
            string _sNormalToObjCollection, string _sNormalToObjName,
            string _sThroughPntCollection, string _sThroughPntGroup, string _sThroughPntName,
            double _dPlaneEdgeDimension)
        {
            NrkSdk.SetStep("Construct Plane, Normal to Object, Through Point");
            NrkSdk.SetCollectionObjectNameArg("Resultant Plane Name", _sResultantPlaneCollection, _sResultantPlaneName);
            NrkSdk.SetCollectionObjectNameArg("'Normal to' Object Name", _sNormalToObjCollection, _sNormalToObjName);
            NrkSdk.SetPointNameArg("'Through' Point Name", _sThroughPntCollection, _sThroughPntGroup, _sThroughPntName);
            NrkSdk.SetDoubleArg("Plane Edge Dimension", _dPlaneEdgeDimension);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructPlanesBoundingPointGroup(string _sReferencePlaneCollection, string _sReferencePlaneName,
            string _sGroupToBoundCollection, string _sGroupToBoundName,
            string _sResultingHighPlaneCollection, string _sResultingHighPlaneName,
            string _sResultingLowPlaneCollection, string _sResultingLowPlaneName,
            bool _bOverideTargetPointOffset, double _dOffsetValue)
        {
            NrkSdk.SetStep("Construct Planes, Bounding Point Group");
            NrkSdk.SetCollectionObjectNameArg("Reference Plane Name", _sReferencePlaneCollection, _sReferencePlaneName);
            NrkSdk.SetCollectionObjectNameArg("Group to bound", _sGroupToBoundCollection, _sGroupToBoundName);
            NrkSdk.SetCollectionObjectNameArg("Resulting 'High' Plane Name", _sResultingHighPlaneCollection, _sResultingHighPlaneName);
            NrkSdk.SetCollectionObjectNameArg("Resulting 'Low' Plane Name", _sResultingLowPlaneCollection, _sResultingLowPlaneName);
            NrkSdk.SetBoolArg("Override Target/Point Offsets", _bOverideTargetPointOffset);
            NrkSdk.SetDoubleArg("Offset Value", _dOffsetValue);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ShiftPlane(string _sPlaneCollection, string _sPlaneName,
            double _dShiftAlongNormal, double _dGrowBoundsByFactor)
        {
            NrkSdk.SetStep("Shift Plane");
            NrkSdk.SetCollectionObjectNameArg("Plane", _sPlaneCollection, _sPlaneName);
            NrkSdk.SetDoubleArg("Shift Along Normal", _dShiftAlongNormal);
            NrkSdk.SetDoubleArg("Grow Bounds by Factor", _dGrowBoundsByFactor);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructPlanesFromSurfaceFacesRuntimeSelect()
        {
            NrkSdk.SetStep("Construct Planes From Surface Faces - Runtime Select");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructCircle(string _sCircleCollection, string _sCircleName,
            double _dCircleCenterX, double _dCircleCenterY, double _dCircleCenterZ,
            double _dCircleNormalX, double _dCircleNormalY, double _dCircleNormalZ,
            double _dCircleRadius)
        {
            NrkSdk.SetStep("Construct Circle");
            NrkSdk.SetCollectionObjectNameArg("Circle Name", _sCircleCollection, _sCircleName);
            NrkSdk.SetVectorArg("Circle Center (in working coordinates)", _dCircleCenterX, _dCircleCenterY, _dCircleCenterZ);
            NrkSdk.SetVectorArg("Circle Normal (in working coordinates)", _dCircleNormalX, _dCircleNormalY, _dCircleNormalZ);
            NrkSdk.SetDoubleArg("Circle Radius", _dCircleRadius);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructCirclesFromSurfaceFacesRuntimeSelect()
        {
            NrkSdk.SetStep("Construct Circles From Surface Faces - Runtime Select");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructCylinder(string _sCylinderCollection, string _sCylinderName,
            double _dEndPointX, double _dEndPointY, double _dEndPointZ,
            double _dAxisX, double _dAxisY, double _dAxisZ,
            double _dCylinderDiameter, double _dCylinderLength)
        {
            NrkSdk.SetStep("Construct Cylinder");
            NrkSdk.SetCollectionObjectNameArg("Cylinder Name", _sCylinderCollection, _sCylinderName);
            NrkSdk.SetVectorArg("Cylinder End Point (in working coordinates)", _dEndPointX, _dEndPointY, _dEndPointZ);
            NrkSdk.SetVectorArg("Cylinder Axis (in working coordinates)", _dAxisX, _dAxisY, _dAxisZ);
            NrkSdk.SetDoubleArg("Cylinder Diameter", _dCylinderDiameter);
            NrkSdk.SetDoubleArg("Cylinder Length", _dCylinderLength);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructCylinderFromEndPoints(string _sCylinderCollection, string _sCylinderName,
            double _dCylinderEndPAX, double _dCylinderEndPAY, double _dCylinderEndPAZ,
            double _dCylinderEndPBX, double _dCylinderEndPBY, double _dCylinderEndPBZ,
            double _dCylinderDiameter)
        {
            NrkSdk.SetStep("Construct Cylinder From End Points");
            NrkSdk.SetCollectionObjectNameArg("Cylinder Name", _sCylinderCollection, _sCylinderName);
            NrkSdk.SetVectorArg("Cylinder End Point A (in working coordinates)", _dCylinderEndPAX, _dCylinderEndPAY, _dCylinderEndPAZ);
            NrkSdk.SetVectorArg("Cylinder End Point B (in working coordinates)", _dCylinderEndPBX, _dCylinderEndPBY, _dCylinderEndPBZ);
            NrkSdk.SetDoubleArg("Cylinder Diameter", _dCylinderDiameter);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructCylindersFromSurfaceFacesRuntimeSelect()
        {
            NrkSdk.SetStep("Construct Cylinders From Surface Faces - Runtime Select");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructSphere(string _sSphereCollection, string _sShpereName,
            double _dSphereCenterX, double _dSphereCenterY, double _dSphereCenterZ,
            double _dSphereRadius)
        {
            NrkSdk.SetStep("Construct Sphere");
            NrkSdk.SetCollectionObjectNameArg("Sphere Name", _sSphereCollection, _sShpereName);
            NrkSdk.SetVectorArg("Sphere Center (in working coordinates)", _dSphereCenterX, _dSphereCenterY, _dSphereCenterZ);
            NrkSdk.SetDoubleArg("Sphere Radius", _dSphereRadius);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructSpheresFromSurfaceFacesRuntimeSelect()
        {
            NrkSdk.SetStep("Construct Spheres From Surface Faces - Runtime Select");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructCone(string _sConeCollection, string _sConeName,
            double _dConeEndPointX, double _dConeEndPointY, double _dConeEndPointZ,
            double _dConeAxisX, double _dConeAxisY, double _dConeAxisZ,
            double _dConeLeng, double _dConeThetaStart, double _dconeThetaSpan, double _dConeIncludedAngle)
        {
            NrkSdk.SetStep("Construct Cone");
            NrkSdk.SetCollectionObjectNameArg("Cone Name", _sConeCollection, _sConeName);
            NrkSdk.SetVectorArg("Cone End Point (in working coordinates)", _dConeEndPointX, _dConeEndPointY, _dConeEndPointZ);
            NrkSdk.SetVectorArg("Cone Axis (in working coordinates)", _dConeAxisX, _dConeAxisY, _dConeAxisZ);
            NrkSdk.SetDoubleArg("Cone Length", _dConeLeng);
            NrkSdk.SetDoubleArg("Cone Theta Start", _dConeThetaStart);
            NrkSdk.SetDoubleArg("Cone Theta Span", _dconeThetaSpan);
            NrkSdk.SetDoubleArg("Cone Included Angle", _dConeIncludedAngle);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructConesFromSurfaceFacesRuntimeSelect()
        {
            NrkSdk.SetStep("Construct Cones From Surface Faces - Runtime Select");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        //        public bool ConstructBSplineFromPoints()
        //        {
        //NrkSdk.SetStep("Construct B-Spline From Points");
        //	NrkSdk.SetCollectionObjectNameArg("Resulting B-Spline Name", "", "");
        //	NrkSdk.NOT_SUPPORTED("B-Spline Fit Options");
        //	CStringArray ptNameList;
        //        SDKHelper helper(NrkSdk);
        //        helper.SetPointNameRefListArgHelper("Point List", ptNameList);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        //    public bool (){
        //NrkSdk.SetStep("Construct B-Spline From Several B-Splines");
        //	NrkSdk.SetCollectionObjectNameArg("Resulting B-Spline Name", "", "");
        //	CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("B-SPline List", objNameList);
        //	NrkSdk.SetBoolArg("Close Resulting B-Spline", FALSE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        //public bool (){
        //NrkSdk.SetStep("Construct B-Splines From Lines");
        //	NrkSdk.SetStringArg("Resulting BSpline Name prefix (Optional)", "");
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("Line List", objNameList);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}
        //CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.GetCollectionObjectNameRefListArgHelper("B-SPline List", objNameList);

        public bool ConstructBSplineFromIntersectionofPlaneandSurface(string _sBSplineCollection, string _sBSplineName,
            string _sPlaneCollection, string _sPlaneName,
            string _sSurfaceCollection, string _sSurfaceName,
            double _dTol)
        {
            NrkSdk.SetStep("Construct B-Spline From Intersection of Plane and Surface");
            NrkSdk.SetCollectionObjectNameArg("Resulting B-Spline Name", _sBSplineCollection, _sBSplineName);
            NrkSdk.SetCollectionObjectNameArg("Plane Name", _sPlaneCollection, _sPlaneName);
            NrkSdk.SetCollectionObjectNameArg("Surface Name", _sSurfaceCollection, _sSurfaceName);
            NrkSdk.SetDoubleArg("Approximation Tolerance", _dTol);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool ConstructBSplineFromIntersectionOfSurfaces(string _sBSplineCollection, string _sBSplineName,
            string _sFirstSurfaceCollection, string _sFirstSurfaceName,
            string _sSecondSurfaceCollection, string _sSecondeSurfaceName,
            double _dTol)
        {
            NrkSdk.SetStep("Construct B-Spline From Intersection of Surfaces");
            NrkSdk.SetCollectionObjectNameArg("Resulting B-Spline Name", _sBSplineCollection, _sBSplineName);
            NrkSdk.SetCollectionObjectNameArg("First Surface Name", _sFirstSurfaceCollection, _sFirstSurfaceName);
            NrkSdk.SetCollectionObjectNameArg("Second Surface Name", _sSecondSurfaceCollection, _sSecondeSurfaceName);
            NrkSdk.SetDoubleArg("Approximation Tolerance", _dTol);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //    public bool GetInstrumentList()
        //    {
        //NrkSdk.SetStep("Get i-th Instrument From Collection Instrument Ref List");
        //var[] instObjList = new var[1];
        //    object vInstIdList = new System.Runtime.InteropServices.VariantWrapper(instObjList);
        //    NrkSdk.SetColInstIdRefListArg("Collection Instrument Reference List", vInstIdList);
        //NrkSdk.SetIntegerArg("Index", 0);
        //NrkSdk.ExecuteStep();

        //string sCol;
        //    int instId;
        //    NrkSdk.GetColInstIdArg("Resulting Instrument", sCol, instId);
        //}


        //        public bool ConstructSurfacesFromObjects()
        //        {
        //NrkSdk.SetStep("Construct Surfaces From Objects");
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("Objects", objNameList);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}

        //        public bool (){
        //NrkSdk.SetStep("Construct Surface From BSplines");
        //	NrkSdk.SetCollectionObjectNameArg("Resulting Surface Name", "", "");
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("BSpline List", objNameList);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        public bool ConstructSurfaceFromCylinder(string _sSurfaceCollection, string _sSurfaceName,
                string _sSylinderCollection, string _sSylinderName,
                bool _bInternalCylinder)
        {
            NrkSdk.SetStep("Construct Surface From Cylinder");
            NrkSdk.SetCollectionObjectNameArg("Resulting Surface Name", _sSurfaceCollection, _sSurfaceName);
            NrkSdk.SetCollectionObjectNameArg("Cylinder Name", _sSylinderCollection, _sSylinderName);
            NrkSdk.SetBoolArg("Internal Cylinder?", _bInternalCylinder);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool ConstructSurfaceFromPlane(string _sSurfaceCollection, string _sSurfaceName,
            string _sPlaneCollection, string _sPlaneName)
        {
            NrkSdk.SetStep("Construct Surface From Plane");
            NrkSdk.SetCollectionObjectNameArg("Resulting Surface Name", _sSurfaceCollection, _sSurfaceName);
            NrkSdk.SetCollectionObjectNameArg("Plane Name", _sPlaneCollection, _sPlaneName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructSurfaceFromSphere(string _sSurfaceCollection, string _sSurfaceName,
            string _sSphereCollection, string _sShpereName)
        {
            NrkSdk.SetStep("Construct Surface From Sphere");
            NrkSdk.SetCollectionObjectNameArg("Resulting Surface Name", _sSurfaceCollection, _sSurfaceName);
            NrkSdk.SetCollectionObjectNameArg("Sphere Name", _sSphereCollection, _sShpereName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructSurfaceFromCone(string _sSurfaceCollection, string _sSurfaceName,
                string _sConeCollection, string _sConeName)
        {

            NrkSdk.SetStep("Construct Surface From Cone");
            NrkSdk.SetCollectionObjectNameArg("Resulting Surface Name", _sSurfaceCollection, _sSurfaceName);
            NrkSdk.SetCollectionObjectNameArg("Cone Name", _sConeCollection, _sConeName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //        public bool ConstructSurfaceFitFromNominalSurfacesAndActualData(){

        //NrkSdk.SetStep("Construct Surface Fit From Nominal Surfaces and Actual Data");
        //	NrkSdk.SetCollectionObjectNameArg("Nominal Surface", "", "");
        //	CStringArray ptNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetPointNameRefListArgHelper("Actual Data Point List", ptNameList);
        //	NrkSdk.SetCollectionObjectNameArg("Resulting Surface Name", "", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();return bExcuteStatus;}


        public bool ConstructSurfaceByDissectingSurface(string _sDissectionMode)
        {
            NrkSdk.SetStep("Construct Surface by Dissecting Surface(s)");
            // Available options: 
            // "Entire Solid", "Select Faces", 
            NrkSdk.SetSurfDissectModeTypeArg("Dissection Mode", _sDissectionMode);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //        public bool ConstructSurfaceFromPointGroups()
        //        {
        //NrkSdk.SetStep("Construct Surface From Point Groups");
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("Group Name List", objNameList);
        //	NrkSdk.NOT_SUPPORTED("B-Spline Fit Options");
        //	NrkSdk.SetCollectionObjectNameArg("Resulting Surface Name", "", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            return bExcuteStatus;
        //        }



        //        public bool ConstructPolygonizedSurfaceFromPointClouds()
        //        {
        //NrkSdk.SetStep("Construct Polygonized Surface from Point Clouds");
        //	CStringArray objNameList;
        //SDKHelper helper(NrkSdk);
        //helper.SetCollectionObjectNameRefListArgHelper("Point Cloud List", objNameList);
        //	// Available options: 
        //	// "Use Current Point of View", "Use Current Working Frame", 
        //	NrkSdk.SetMeshOrientationTypeArg("Mesh Orientation", "");
        //	NrkSdk.SetDoubleArg("Grid Resolution", 0.000000);
        //	NrkSdk.SetCollectionObjectNameArg("Polygonized Surface Name", "", "");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            return bExcuteStatus;
        //        }


        public bool ConstructFrameWithWizard(string _sFlameColletion, string _sFlameName, bool _bWaitForCompletion)
        {
            NrkSdk.SetStep("Construct Frame with Wizard");
            NrkSdk.SetCollectionObjectNameArg("New Frame Name", _sFlameColletion, _sFlameName);
            NrkSdk.SetBoolArg("Wait for Completion", _bWaitForCompletion);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool ConstructFrame(string _sCol, string _sName, double[,] _sTransform)
        {
            NrkSdk.SetStep("Construct Frame");
            NrkSdk.SetCollectionObjectNameArg("New Frame Name", _sCol, _sName);
            NrkSdk.SetTransformArg("Transform in Working Coordinates", _sTransform);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool ConstructFrameOnInstrumentBase(string _sInsCollection, int _iInsID, string _sFrameName)
        {
            NrkSdk.SetStep("Construct Frame on Instrument Base");
            NrkSdk.SetColInstIdArg("Instrument ID", _sInsCollection, _iInsID);
            NrkSdk.SetFrameNameArg("Frame Name (Optional)", _sFrameName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructFrameOnObject(string _sObjCollection, string _sObjName,
            string _sFrameColletion, string _sFrameName)
        {
            NrkSdk.SetStep("Construct Frame on Object");
            NrkSdk.SetCollectionObjectNameArg("Reference Object", _sObjCollection, _sObjName);
            NrkSdk.SetCollectionObjectNameArg("Frame Name (Optional)", _sFrameColletion, _sFrameName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        //public bool ConstructFrame3Points(string _sOriginPCollection, string _sOriginPGroup, string _sOriginPName,
        //   string _sPrimaryAPCollection, string _sPrimaryAPGroup, string _sPrimaryAPName,
        //   string _sSecondaryAPCollection, string _sSecondaryAPGroup, string _sSecondaryAPName,
        //   string _sFrameName
        //    )
        //{

        //    NrkSdk.SetStep("Construct Frame, 3 Points");
        //    NrkSdk.NOT_SUPPORTED("Construction Method");
        //    NrkSdk.SetPointNameArg("Origin Point", _sOriginPCollection, _sOriginPGroup, _sOriginPName);
        //    NrkSdk.SetPointNameArg("Primary Axis Point", _sPrimaryAPCollection, _sPrimaryAPGroup, _sPrimaryAPName);
        //    NrkSdk.SetPointNameArg("Secondary Axis Point", _sSecondaryAPCollection, _sSecondaryAPGroup, _sSecondaryAPName);
        //    NrkSdk.SetFrameNameArg("Frame Name (Optional)", _sFrameName);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        public bool ConstructFrameAtPointWithWorkingZAndClockedAxis(string _sOriginPCollection, string _sOriginPGroup, string _sOriginPName,
           string _sClockedAxis, string _sClockPCollection, string _sClockPGroup, string _sClockPName,
           string _sFrameName = "")
        {
            NrkSdk.SetStep("Construct Frame, at Point, with working Z, and clocked axis");
            NrkSdk.SetPointNameArg("Origin Point", _sOriginPCollection, _sOriginPGroup, _sOriginPName);
            // Available options: 
            // "+X Axis", "-X Axis", "+Y Axis", "-Y Axis", "+Z Axis", 
            // "-Z Axis", 
            NrkSdk.SetAxisNameArg("Clocked axis", _sClockedAxis);
            NrkSdk.SetPointNameArg("Clocking Point", _sClockPCollection, _sClockPGroup, _sClockPName);
            NrkSdk.SetFrameNameArg("Frame Name (Optional)", _sFrameName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ConstructFramePickOriginAndPointOnXAxisClockZAlongWorkingZ
            (string _sOriginPCollection, string _sOriginPGroup, string _sOriginPName,
            string _sPOnXAxisCollection, string _sPOnXAxisGroup, string _sPOnXAxisName,
            string _sFrameName = ""
            )
        {
            NrkSdk.SetStep("Construct Frame, Pick origin and point on X axis - clock Z along working Z");
            NrkSdk.SetPointNameArg("Origin Point", _sOriginPCollection, _sOriginPGroup, _sOriginPName);
            NrkSdk.SetPointNameArg("Point on X-Axis", _sPOnXAxisCollection, _sPOnXAxisGroup, _sPOnXAxisName);
            NrkSdk.SetFrameNameArg("Frame Name (Optional)", _sFrameName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //public bool ConstructFrameKnownOriginObjectDirectionObjectDirection()
        //{
        //    NrkSdk.SetStep("Construct Frame, Known Origin, Object Direction, Object Direction");
        //    NrkSdk.SetPointNameArg("Known Point", "", "", "");
        //    NrkSdk.SetVectorArg("Known Point Value in New Frame", 0.000000, 0.000000, 0.000000);
        //    NrkSdk.SetCollectionObjectNameArg("Primary Axis Object", "", "");
        //    // Available options: 
        //    // "+X Axis", "-X Axis", "+Y Axis", "-Y Axis", "+Z Axis", 
        //    // "-Z Axis", 
        //    NrkSdk.SetAxisNameArg("Primary Axis Defines Which Axis", "");
        //    NrkSdk.SetCollectionObjectNameArg("Secondary Axis Object", "", "");
        //    // Available options: 
        //    // "+X Axis", "-X Axis", "+Y Axis", "-Y Axis", "+Z Axis", 
        //    // "-Z Axis", 
        //    NrkSdk.SetAxisNameArg("Secondary Axis Defines Which Axis", "");
        //    NrkSdk.SetCollectionObjectNameArg("Frame Name (Optional)", "", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool ConstructFrame3Planes()
        //{
        //    NrkSdk.SetStep("Construct Frame, 3 Planes");
        //    NrkSdk.SetCollectionObjectNameArg("X Plane", "", "");
        //    NrkSdk.SetDoubleArg("X Value on PLane", 0.000000);
        //    NrkSdk.SetCollectionObjectNameArg("Y Plane", "", "");
        //    NrkSdk.SetDoubleArg("Y Value on PLane", 0.000000);
        //    NrkSdk.SetCollectionObjectNameArg("Z Plane", "", "");
        //    NrkSdk.SetDoubleArg("Z Value on Plane", 0.000000);
        //    NrkSdk.SetCollectionObjectNameArg("Frame Name (Optional)", "", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool ConstructFrameCopyAndMakeLeftHanded()
        //{
        //    NrkSdk.SetStep("Construct Frame - Copy And Make Left Handed");
        //    NrkSdk.SetCollectionObjectNameArg("Reference Frame", "", "");
        //    NrkSdk.SetCollectionObjectNameArg("Frame Name (Optional)", "", "");
        //    NrkSdk.NOT_SUPPORTED("Axis to reverse");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool ConstructFrameAverageOfOtherObjectFrames()
        //{
        //    NrkSdk.SetStep("Construct Frame - Average of Other Object Frames");
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Objects", objNameList);
        //    NrkSdk.SetCollectionObjectNameArg("Frame Name (Optional)", "", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool ConstructFrameAtRobotLink()
        //{
        //    NrkSdk.SetStep("Construct Frame at Robot Link");
        //    NrkSdk.SetColMachineIdArg("Machine ID", "", );
        //    NrkSdk.SetStringArg("Link Name", "");
        //    NrkSdk.SetCollectionObjectNameArg("Resulting Frame", "", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool ConstructPerimeterFromPoints()
        //{
        //    NrkSdk.SetStep("Construct Perimeter From Points");
        //    NrkSdk.SetPerimeterNameArg("Resulting Perimeter Name", "");
        //    CStringArray ptNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetPointNameRefListArgHelper("Point List", ptNameList);
        //    NrkSdk.SetBoolArg("Open Perimeter?", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        public bool ConstructAVectorGroupGroupToGroupCompare(string _sVectorCollection, string _sVectorName,
            string _sGroupACollection, string _sGroupAName,
            string _sGroupBCollection, string _sGroupBName,
            double _dRMSDevTol,
            double _dMaxAbsDevTol,
            double _dAverageDevTol,
            ref int _iVecCount,
            ref double _dRMSDev,
            ref double _dMaxDev,
            ref double _dAvgDev)
        {

            NrkSdk.SetStep("Construct a Vector Group - Group to Group Compare");
            NrkSdk.SetCollectionObjectNameArg("Vector Group Name", _sVectorCollection, _sVectorName);
            NrkSdk.SetCollectionObjectNameArg("Group A", _sGroupACollection, _sGroupAName);
            NrkSdk.SetCollectionObjectNameArg("Group B", _sGroupBCollection, _sGroupBName);
            NrkSdk.SetDoubleArg("RMS Deviation Tolerance (0.0 for none)", _dRMSDevTol);
            NrkSdk.SetDoubleArg("Max Absolute Deviation Tolerance (0.0 for none)", _dMaxAbsDevTol);
            NrkSdk.SetDoubleArg("Average Deviation Tolerance (0.0 for none)", _dAverageDevTol);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetIntegerArg("Vector Count", _iVecCount);
            NrkSdk.GetDoubleArg("RMS Deviation", _dRMSDev);
            NrkSdk.GetDoubleArg("Max Absolute Deviation", _dMaxDev);
            NrkSdk.GetDoubleArg("Average Deviation", _dAvgDev);
            return bExcuteStatus;
        }

        //public bool ConstructAVectorGroupAreaProfileCheck()
        //    {
        //    NrkSdk.SetStep("Construct a Vector Group - Area Profile Check");
        //    CStringArray vectorNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetVectorNameRefListArgHelper("Reference Vectors", vectorNameList);
        //    CStringArray vgNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionVectorGroupNameRefListArgHelper("Vector Groups to Check", vgNameList);
        //    NrkSdk.SetDoubleArg("Area Radius", 0.000000);
        //    NrkSdk.SetDoubleArg("Area Tolerance", 0.000000);
        //    NrkSdk.SetColVectorGroupNameArg("Resultant Vector Group Name", "", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool ConstructAVectorInWorkingCoordinatesBeginDelta()
        //{
        //    NrkSdk.SetStep("Construct a Vector in Working Coordinates(Begin/Delta)");
        //    NrkSdk.SetCollectionObjectNameArg("Vector Group Name", "", "");
        //    NrkSdk.SetStringArg("New Vector Name", "");
        //    NrkSdk.SetVectorArg("'Begin' in Working Coordinates", 0.000000, 0.000000, 0.000000);
        //    NrkSdk.SetVectorArg("'Delta' in Working Coordinates", 0.000000, 0.000000, 0.000000);
        //    NrkSdk.SetBoolArg("Is Magnitude Negative", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool ConstructAVectorInWorkingCoordinatesBeginDirectionMag()
        //{
        //    NrkSdk.SetStep("Construct a Vector in Working Coordinates(Begin/Direction/Mag.)");
        //    NrkSdk.SetCollectionObjectNameArg("Vector Group Name", "", "");
        //    NrkSdk.SetStringArg("New Vector Name", "");
        //    NrkSdk.SetVectorArg("'Begin' in Working Coordinates", 0.000000, 0.000000, 0.000000);
        //    NrkSdk.SetVectorArg("'Direction' in Working Coordinates", 0.000000, 0.000000, 0.000000);
        //    NrkSdk.SetDoubleArg("Signed Magnitude", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool ConstructVectorsWildCardSelection()
        //{
        //    NrkSdk.SetStep("Construct Vectors WildCard Selection");
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Vector Groups to Select From", objNameList);
        //    NrkSdk.NOT_SUPPORTED("WildCard Selection Names");
        //    NrkSdk.SetCollectionObjectNameArg("Vector Group for New Vectors", "", "");
        //    NrkSdk.SetBoolArg("Include prior complete name", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        public bool ConstructAVectorGroupFromARelationship(string _sRelationShipCollection, string _sRelationShipName,
            string _sVectorGroupCollection, string _sVectorGroupName)
        {
            NrkSdk.SetStep("Construct a Vector Group From a Relationship");
            NrkSdk.SetCollectionObjectNameArg("Relationship Name", _sRelationShipCollection, _sRelationShipName);
            NrkSdk.SetColVectorGroupNameArg("Vector Group Name", _sVectorGroupCollection, _sVectorGroupName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool MakeFeatureChecks(string _sCollection)
        {
            NrkSdk.SetStep("Make Feature Checks");
            NrkSdk.SetCollectionNameArg("Collection Name", _sCollection);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //public bool MakeAFeatureCheckRefListFromACollection()
        //{
        //    NrkSdk.SetStep("Make a Feature Check Ref List from a Collection");
        //    NrkSdk.SetCollectionNameArg("Collection Name", "");
        //    NrkSdk.NOT_SUPPORTED("Feature Check Ref List");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool MakeAFeatureCheckReferenceListWildCardSelection()
        //{
        //    NrkSdk.SetStep("Make a Feature Check Reference List- WildCard Selection");
        //    NrkSdk.SetStringArg("Collection Wildcard Criteria", "*");
        //    NrkSdk.SetStringArg("Feature Check Wildcard Criteria", "*");
        //    NrkSdk.NOT_SUPPORTED("Resultant Feature Check Reference List");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool DeleteFeatureChecks()
        //{
        //    NrkSdk.SetStep("Delete Feature Checks");
        //    NrkSdk.NOT_SUPPORTED("Feature Check Name List");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool MakeADatumRefListFromACollection()
        //{
        //    NrkSdk.SetStep("Make a Datum Ref List from a Collection");
        //    NrkSdk.SetCollectionNameArg("Collection Name", "");
        //    NrkSdk.NOT_SUPPORTED("Datum Ref List");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        public bool ConstructFolder(string _sFolderPath)
        {
            NrkSdk.SetStep("Construct Folder(s)");
            NrkSdk.SetStringArg("Folder Path", _sFolderPath);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool DeleteFoldersByWildcard(string _sSearchString, ref int _iNumDeleted, ref int _iNumFailed, bool _bCaseSensitive = true, bool _bAllowDeleteAllFolders = false
            )
        {
            NrkSdk.SetStep("Delete Folders by Wildcard");
            NrkSdk.SetStringArg("Search String", "");
            NrkSdk.SetBoolArg("Case Sensitive Search", _bCaseSensitive);
            NrkSdk.SetBoolArg("Allow Deleting all Folders", _bAllowDeleteAllFolders);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetIntegerArg("Num Deleted", _iNumDeleted);
            NrkSdk.GetIntegerArg("Num Failed", _iNumFailed);
            return bExcuteStatus;
        }


        //public bool CreateVectorCallout()
        //{
        //    NrkSdk.SetStep("Create Vector Callout");
        //    NrkSdk.NOT_SUPPORTED("Destination Callout View");
        //    NrkSdk.SetCollectionObjectNameArg("Vector Group Name", "", "");
        //    NrkSdk.SetStringArg("Vector Name", "");
        //    NrkSdk.SetDoubleArg("View X Position", 0.000000);
        //    NrkSdk.SetDoubleArg("View Y Position", 0.000000);
        //    NrkSdk.SetBoolArg("Show Collection?", FALSE);
        //    NrkSdk.SetBoolArg("Show Vector Group?", FALSE);
        //    NrkSdk.SetBoolArg("Show Vector Name?", TRUE);
        //    NrkSdk.SetBoolArg("Show dX?", TRUE);
        //    NrkSdk.SetBoolArg("Show dY?", TRUE);
        //    NrkSdk.SetBoolArg("Show dZ?", TRUE);
        //    NrkSdk.SetBoolArg("Show dMag?", TRUE);
        //    NrkSdk.SetBoolArg("Show Tolerance Color?", TRUE);
        //    NrkSdk.SetBoolArg("Show Start Point?", FALSE);
        //    NrkSdk.SetBoolArg("Show End Point?", FALSE);
        //    NrkSdk.SetStringArg("Additional Notes (blank for none)", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool CreatePointComparisonCallout()
        //{
        //    NrkSdk.SetStep("Create Point Comparison Callout");
        //    NrkSdk.NOT_SUPPORTED("Destination Callout View");
        //    NrkSdk.SetPointNameArg("First Point", "", "", "");
        //    NrkSdk.SetPointNameArg("Second Point", "", "", "");
        //    NrkSdk.SetDoubleArg("View X Position", 0.000000);
        //    NrkSdk.SetDoubleArg("View Y Position", 0.000000);
        //    NrkSdk.SetBoolArg("Show First Point Collection?", FALSE);
        //    NrkSdk.SetBoolArg("Show First Point Group?", TRUE);
        //    NrkSdk.SetBoolArg("Show First Point Target?", TRUE);
        //    NrkSdk.SetBoolArg("Show First Point Coordinates?", FALSE);
        //    NrkSdk.SetBoolArg("Show Second Point Collection?", FALSE);
        //    NrkSdk.SetBoolArg("Show Second Point Group?", TRUE);
        //    NrkSdk.SetBoolArg("Show Second Point Target?", TRUE);
        //    NrkSdk.SetBoolArg("Show Second Point Coordinates?", FALSE);
        //    NrkSdk.SetBoolArg("Show dX?", TRUE);
        //    NrkSdk.SetBoolArg("Show dY?", TRUE);
        //    NrkSdk.SetBoolArg("Show dZ?", TRUE);
        //    NrkSdk.SetBoolArg("Show dMag?", TRUE);
        //    NrkSdk.SetStringArg("Additional X Comments (blank for none)", "");
        //    NrkSdk.SetStringArg("Additional Y Comments (blank for none)", "");
        //    NrkSdk.SetStringArg("Additional Z Comments (blank for none)", "");
        //    NrkSdk.SetStringArg("Additional Notes (blank for none)", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool CreateRelationshipCallout()
        //{

        //    NrkSdk.SetStep("Create Relationship Callout");
        //    NrkSdk.NOT_SUPPORTED("Destination Callout View");
        //    NrkSdk.SetCollectionObjectNameArg("Relationship Name", "", "");
        //    NrkSdk.SetDoubleArg("View X Position", 0.000000);
        //    NrkSdk.SetDoubleArg("View Y Position", 0.000000);
        //    NrkSdk.SetStringArg("Additional Notes (blank for none)", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool DeleteCalloutView()
        //{
        //    NrkSdk.SetStep("Delete Callout View");
        //    NrkSdk.NOT_SUPPORTED("Callout View");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep(); return bExcuteStatus;
        //}

        //public bool RenameCalloutView()
        //{
        //    NrkSdk.SetStep("Rename Callout View");
        //    NrkSdk.NOT_SUPPORTED("Original Callout View Name");
        //    NrkSdk.NOT_SUPPORTED("New Callout View Name");
        //    NrkSdk.SetBoolArg("Overwrite if exists?", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}
        //public bool MakeABoolean()
        //{
        //    NrkSdk.SetStep("Make a Boolean");
        //    NrkSdk.SetBoolArg("Initial Value", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    BOOL bValue;
        //    NrkSdk.GetBoolArg("Result", &bValue);
        //    return bExcuteStatus;
        //}

        //public bool MakeAInteger()
        //{
        //    NrkSdk.SetStep("Make a Integer");
        //    NrkSdk.SetIntegerArg("Initial Value", 0);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    long value;
        //    NrkSdk.GetIntegerArg("Result", &value);
        //    return bExcuteStatus;
        //}

        //public bool MakeAIntegerFromString()
        //{
        //    NrkSdk.SetStep("Make a Integer from String");
        //    NrkSdk.SetStringArg("String Input", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    long value;
        //    NrkSdk.GetIntegerArg("Resultant Integer", &value);

        //    return bExcuteStatus;
        //}


        //public bool MakeADoubleFromAnInteger()
        //{
        //    NrkSdk.SetStep("Make a Double From an Integer");
        //    NrkSdk.SetIntegerArg("Integer Value", 0);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Result", &value);
        //    return bExcuteStatus;
        //}


        //public bool MakeADouble()
        //{
        //    NrkSdk.SetStep("Make a Double");
        //    NrkSdk.SetDoubleArg("Initial Value", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Result", &value);
        //    return bExcuteStatus;
        //}

        //public bool MakeADoubleFromString()
        //{
        //    NrkSdk.SetStep("Make a Double from String");
        //    NrkSdk.SetStringArg("String Input", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Resultant Double", &value);
        //    return bExcuteStatus;
        //}

        //public bool MakeADoubleList()
        //{
        //    NrkSdk.SetStep("Make a Double List");
        //    NrkSdk.NOT_SUPPORTED("Double List");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool AddDoubleToDoubleList()
        //{
        //    NrkSdk.SetStep("Add Double to Double List");
        //    NrkSdk.NOT_SUPPORTED("Double List");
        //    NrkSdk.SetDoubleArg("Value", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //        public bool MakeABooleanFromAnInteger()
        //        {
        //            NrkSdk.SetStep("Make a Boolean From an Integer");
        //            NrkSdk.SetIntegerArg("Integer Value", 0);
        //            bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            BOOL bValue;
        //            NrkSdk.GetBoolArg("Result", &bValue);
        //            return bExcuteStatus;
        //        }

        //        public bool MakeAString()
        //        {
        //            NrkSdk.SetStep("Make a String");
        //            NrkSdk.SetStringArg("Base String", "");
        //            NrkSdk.SetStringArg("String To Append (optional)", "");
        //            bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            BSTR sValue = NULL;
        //            NrkSdk.GetStringArg("Resultant String", &sValue);
        //            CString name = sValue;
        //::SysFreeString(sValue);
        //            return bExcuteStatus;
        //        }

        //        public bool MakeStringFromInteger()
        //        {
        //            NrkSdk.SetStep("Make String from Integer");
        //            NrkSdk.SetIntegerArg("Integer to convert", 0);
        //            NrkSdk.SetIntegerArg("Minimum Digits (will prefix with 0's)", 0);
        //            bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            BSTR sValue = NULL;
        //            NrkSdk.GetStringArg("Resultant String", &sValue);
        //            CString name = sValue;
        //::SysFreeString(sValue);
        //            return bExcuteStatus;
        //        }

        //        public bool MakeStringFromDouble()
        //        {
        //            NrkSdk.SetStep("Make String from Double");
        //            NrkSdk.SetDoubleArg("Double to convert", 0.000000);
        //            NrkSdk.SetIntegerArg("Decimal Precision", 0);
        //            bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            BSTR sValue = NULL;
        //            NrkSdk.GetStringArg("Resultant String", &sValue);
        //            CString name = sValue;
        //::SysFreeString(sValue);
        //            return bExcuteStatus;
        //        }


        //        public bool MakeStringFromDecimalDegreesAngularValue()
        //        {
        //            NrkSdk.SetStep("Make String from Decimal Degrees Angular Value");
        //            NrkSdk.SetDoubleArg("Angular Value (Decimal Degrees)", 0.000000);
        //            NrkSdk.NOT_SUPPORTED("Output Units");
        //            NrkSdk.SetIntegerArg("Decimal Precision", 0);
        //            bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            BSTR sValue = NULL;
        //            NrkSdk.GetStringArg("Resultant String", &sValue);
        //            CString name = sValue;
        //::SysFreeString(sValue);
        //            return bExcuteStatus;
        //        }

        //        public bool MakeAnIncrementedString()
        //        {
        //            NrkSdk.SetStep("Make an Incremented String");
        //            NrkSdk.SetStringArg("Base String", "");
        //            bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            BSTR sValue = NULL;
        //            NrkSdk.GetStringArg("Resultant String", &sValue);
        //            CString name = sValue;
        //::SysFreeString(sValue);
        //            return bExcuteStatus;
        //        }

        //        public bool MakeASystemString()
        //        {
        //            NrkSdk.SetStep("Make a System String");
        //            // Available options: 
        //            // "SA Version", "XIT Filename", "MP Filename", "MP Filename (Full Path)", "Date & Time", 
        //            // "Date", "Date (Short)", "Time", 
        //            NrkSdk.SetSystemStringArg("String Content", "");
        //            NrkSdk.SetStringArg("Format String (Optional)", "");
        //            bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            BSTR sValue = NULL;
        //            NrkSdk.GetStringArg("Resultant String", &sValue);
        //            CString name = sValue;
        //::SysFreeString(sValue);
        //            return bExcuteStatus;
        //        }

        //        public bool ConcatenateStrings()
        //        {
        //            NrkSdk.SetStep("Concatenate Strings");
        //            CStringArray stringList;
        //            SDKHelper helper(NrkSdk);
        //            helper.SetStringRefListArgHelper("Input Strings", stringList);
        //            BSTR sValue = NULL;
        //            NrkSdk.GetStringArg("Resultant String", &sValue);
        //            CString name = sValue;
        //::SysFreeString(sValue); bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            return bExcuteStatus;
        //        }

        //        public bool MakeAStringRefList()
        //        {
        //            NrkSdk.SetStep("Make a String Ref List");
        //            CStringArray stringList;
        //            SDKHelper helper(NrkSdk);
        //            helper.SetStringRefListArgHelper("String List", stringList);
        //            bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            return bExcuteStatus;
        //        }

        //        public bool MakeAStringFromAStringRefList()
        //        {
        //            NrkSdk.SetStep("Make a String from a String Ref List");
        //            CStringArray stringList;
        //            SDKHelper helper(NrkSdk);
        //            helper.SetStringRefListArgHelper("String List", stringList);
        //            bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            BSTR sValue = NULL;
        //            NrkSdk.GetStringArg("Resultant String", &sValue);
        //            CString name = sValue;
        //::SysFreeString(sValue);
        //            return bExcuteStatus;
        //        }

        //        public bool MakeStringsFromAPointName(string _sPntCollection,string _sPntGroup,string _sPntName)
        //        {
        //            NrkSdk.SetStep("Make Strings from a Point Name");
        //            NrkSdk.SetPointNameArg("Point Name", _sPntCollection, _sPntGroup, _sPntName);
        //            bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            BSTR sValue = NULL;
        //            NrkSdk.GetStringArg("Collection", &sValue);
        //            CString name = sValue;
        //::SysFreeString(sValue);

        //            BSTR sValue = NULL;
        //            NrkSdk.GetStringArg("Group", &sValue);
        //            CString name = sValue;
        //::SysFreeString(sValue);
        //            BSTR sValue = NULL;
        //            NrkSdk.GetStringArg("Target", &sValue);
        //            CString name = sValue;
        //::SysFreeString(sValue);

        //            return bExcuteStatus;
        //        }

        //        public bool MakeStringsFromACollectionObjectName()
        //        {
        //            NrkSdk.SetStep("Make Strings from a Collection Object Name");
        //            NrkSdk.SetCollectionObjectNameArg("Resultant Collection Object Name", "", "");
        //            bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            BSTR sValue = NULL;
        //            NrkSdk.GetStringArg("Collection", &sValue);
        //            CString name = sValue;
        //::SysFreeString(sValue);

        //            BSTR sValue = NULL;
        //            NrkSdk.GetStringArg("Object", &sValue);
        //            CString name = sValue;
        //::SysFreeString(sValue);

        //            BSTR sValue = NULL;
        //            NrkSdk.GetStringArg("Object Type", &sValue);
        //            CString name = sValue;
        //::SysFreeString(sValue);
        //            return bExcuteStatus;
        //        }

        //        public bool MakeAPointNamefromStrings()
        //        {
        //            NrkSdk.SetStep("Make a Point Name from Strings");
        //            NrkSdk.SetStringArg("Collection", "");
        //            NrkSdk.SetStringArg("Group", "");
        //            NrkSdk.SetStringArg("Target", "");
        //            bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            BSTR sCol = NULL;
        //            BSTR sGrp = NULL;
        //            BSTR sTarg = NULL;
        //            NrkSdk.GetPointNameArg("Resultant Point Name", &sCol, &sGrp, &sTarg);
        //            CString collection = sCol;
        //            CString group = sGrp;
        //            CString target = sTarg;
        //::SysFreeString(sCol);
        //::SysFreeString(sGrp);
        //::SysFreeString(sTarg);
        //            return bExcuteStatus;
        //        }

        public bool MakeAPointNameRuntimeSelect(string _sUserPrompt, ref string _sCol, ref string _sGrp, ref string _sTarg)
        {
            NrkSdk.SetStep("Make a Point Name - Runtime Select");
            NrkSdk.SetStringArg("User Prompt", "");
            bool bExcuteStatus = NrkSdk.ExecuteStep();

            NrkSdk.GetPointNameArg("Resultant Point Name", _sCol, _sGrp, _sTarg);
            return bExcuteStatus;
        }
        public bool GetNumberOfPointsInGroup(string _Col, string _PntGrp, ref int _Number)
        {
            NrkSdk.SetStep("Get Number of Points in Group");
            NrkSdk.SetCollectionObjectNameArg("Group Name", _Col, _PntGrp);
            bool bExcuteStatus = NrkSdk.ExecuteStep();

            if (bExcuteStatus)
            {

                NrkSdk.GetIntegerArg("Total Count", ref _Number);
            }
            return bExcuteStatus;
        }



        public bool MakeAPointNameEnsureUnique(string _sCol, string _sGrp, string _sName, bool _bUseNumberSuffix = false)
        {
            NrkSdk.SetStep("Make a Point Name - Ensure Unique");
            NrkSdk.SetPointNameArg("Point Name", _sCol, _sGrp, _sName);
            NrkSdk.SetBoolArg("Use Number Suffix?", _bUseNumberSuffix);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool MakeAPointNameRefListFromAGroup(string _ColName, string _GrpName, ref List<string> _ptNameList)
        {
            NrkSdk.SetStep("Make a Point Name Ref List From a Group");
            NrkSdk.SetCollectionObjectNameArg("Group Name", _ColName, _GrpName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            Object userPtList = null;

            if (bExcuteStatus)
            {
                if (NrkSdk.GetPointNameRefListArg("Resultant Point Name List", ref userPtList))
                {
                    //对象拆箱
                    object[] myArray = userPtList as object[];
                    string[] Ptlist = Array.ConvertAll(myArray, item => (string)item);

                    if (Ptlist != null)
                    {
                        // 现在可以安全地使用list了
                        for (int i = 0; i < Ptlist.Count(); i++)
                        {
                            _ptNameList.Add(Ptlist[i]);
                        }
                    }
                    else
                    {
                        // obj不是List<T>类型的处理逻辑
                    }
                }
            }



            return bExcuteStatus;
        }


        //public bool MakeAPointNameRefList()
        //{
        //    NrkSdk.SetStep("Make a Point Name Ref List");
        //    CStringArray ptNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetPointNameRefListArgHelper("Point Name List", ptNameList);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool MakeAPointNameRefListRuntimeSelect()
        //{
        //    NrkSdk.SetStep("Make a Point Name Ref List - Runtime Select");
        //    NrkSdk.SetStringArg("User Prompt", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    CStringArray ptNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.GetPointNameRefListArgHelper("Resultant Point Name List", ptNameList);
        //    return bExcuteStatus;
        //}

        //public bool MakeAPointNameRefListWildcardSelect()
        //{
        //    NrkSdk.SetStep("Make a Point Name Ref List - Wildcard Select");
        //    NrkSdk.SetStringArg("Collection Wildcard Criteria", "*");
        //    NrkSdk.SetStringArg("Group Name Wildcard Criteria", "*");
        //    NrkSdk.SetStringArg("Point Name Wildcard Criteria", "*");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    CStringArray ptNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.GetPointNameRefListArgHelper("Resultant Point Name List", ptNameList);
        //    return bExcuteStatus;
        //}


        //public bool MakeAVectorNameRefListFromAVectorGroup()
        //{
        //    NrkSdk.SetStep("Make a Vector Name Ref List From a Vector Group");
        //    NrkSdk.SetCollectionObjectNameArg("Vector Group Name", "", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    CStringArray vectorNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.GetVectorNameRefListArgHelper("Resultant Vector Name List", vectorNameList);

        //    return bExcuteStatus;
        //}

        //public bool AppendTwoPointNameRefLists()
        //{

        //    NrkSdk.SetStep("Append two Point Name Ref Lists");
        //    CStringArray ptNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetPointNameRefListArgHelper("Point Name List A", ptNameList);
        //    CStringArray ptNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetPointNameRefListArgHelper("Point Name List B", ptNameList);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    CStringArray ptNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.GetPointNameRefListArgHelper("Resultant Point Name List(A+B)", ptNameList);

        //    return bExcuteStatus;
        //}

        //        public bool MakeACollectionNameRuntimeSelect()
        //        {
        //            NrkSdk.SetStep("Make a Collection Name - Runtime Select");
        //            NrkSdk.SetStringArg("User Prompt", "");
        //            bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            BSTR sValue = NULL;
        //            NrkSdk.GetCollectionNameArg("Resultant Collection Name", &sValue);
        //            CString name = sValue;
        //::SysFreeString(sValue);
        //            return bExcuteStatus;
        //        }

        public bool MakeACollectionObjectNameFromStrings(string sCol, string sObjName, string sObjType, ref string colName, ref string objName)
        {
            NrkSdk.SetStep("Make a Collection Object Name from Strings");
            NrkSdk.SetStringArg("Collection", sCol);
            NrkSdk.SetStringArg("Object", sObjName);
            // Available options: 
            // "Any", "Circle", "Cloud", "Cone", "Curves", 
            // "Cylinder", "Ellipse", "Frame", "Line", "Paraboloid", 
            // "Perimeter", "Plane", "Point Group", "Poly Surface", "Sphere", 
            // "Spline", "Surface", "Vector Group", 
            NrkSdk.SetObjectTypeArg("Object Type", sObjType);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            if (bExcuteStatus)
            {
                NrkSdk.GetCollectionObjectNameArg("Resultant Collection Object Name", ref colName, ref objName);
            }
            return bExcuteStatus;
        }

        public bool MakeACollectionObjectNameRuntimeSelect(string Prompt, string ObjType, ref string sCol, ref string sObj)
        {
            NrkSdk.SetStep("Make a Collection Object Name - Runtime Select");
            NrkSdk.SetStringArg("User Prompt", Prompt);
            // Available options: 
            // "Any", "Circle", "Cloud", "Cone", "Curves", 
            // "Cylinder", "Ellipse", "Frame", "Line", "Paraboloid", 
            // "Perimeter", "Plane", "Point Group", "Poly Surface", "Sphere", 
            // "Spline", "Surface", "Vector Group", 
            NrkSdk.SetObjectTypeArg("Object Type", ObjType);
            bool bExcuteStatus = NrkSdk.ExecuteStep();

            NrkSdk.GetCollectionObjectNameArg("Resultant Collection Object Name", ref sCol, ref sObj);
            return bExcuteStatus;
        }

        //public bool MakeACollectionObjectNameEnsureUnique()
        //{
        //    NrkSdk.SetStep("Make a Collection Object Name - Ensure Unique");
        //    NrkSdk.SetCollectionObjectNameArg("Collection Object Name", "", "");
        //    NrkSdk.SetBoolArg("Use Number Suffix?", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool MakeACollectionObjectNameReferenceListRuntimeSelect()
        //{
        //    NrkSdk.SetStep("Make a Collection Object Name Reference List- Runtime Select");
        //    NrkSdk.SetStringArg("User Prompt", "");
        //    // Available options: 
        //    // "Any", "Circle", "Cloud", "Cone", "Curves", 
        //    // "Cylinder", "Ellipse", "Frame", "Line", "Paraboloid", 
        //    // "Perimeter", "Plane", "Point Group", "Poly Surface", "Sphere", 
        //    // "Spline", "Surface", "Vector Group", 
        //    NrkSdk.SetObjectTypeArg("Object Type", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.GetCollectionObjectNameRefListArgHelper("Resultant Collection Object Name Reference List", objNameList);
        //    return bExcuteStatus;
        //}

        //public bool MakeACollectionObjectNameReferenceListWildCardSelection()
        //{
        //    NrkSdk.SetStep("Make a Collection Object Name Reference List- WildCard Selection");
        //    NrkSdk.SetStringArg("Collection Wildcard Criteria", "*");
        //    NrkSdk.SetStringArg("Object Wildcard Criteria", "*");
        //    // Available options: 
        //    // "Any", "Circle", "Cloud", "Cone", "Curves", 
        //    // "Cylinder", "Ellipse", "Frame", "Line", "Paraboloid", 
        //    // "Perimeter", "Plane", "Point Group", "Poly Surface", "Sphere", 
        //    // "Spline", "Surface", "Vector Group", 
        //    NrkSdk.SetObjectTypeArg("Object Type", "Any");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.GetCollectionObjectNameRefListArgHelper("Resultant Collection Object Name Reference List", objNameList);
        //    return bExcuteStatus;
        //}

        //public bool MakeACollectionObjectNameRefListByType()
        //{
        //    NrkSdk.SetStep("Make a Collection Object Name Ref List - By Type");
        //    NrkSdk.SetStringArg("Collection", "");
        //    // Available options: 
        //    // "Any", "Circle", "Cloud", "Cone", "Curves", 
        //    // "Cylinder", "Ellipse", "Frame", "Line", "Paraboloid", 
        //    // "Perimeter", "Plane", "Point Group", "Poly Surface", "Sphere", 
        //    // "Spline", "Surface", "Vector Group", 
        //    NrkSdk.SetObjectTypeArg("Object Type", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.GetCollectionObjectNameRefListArgHelper("Resultant Collection Object Name List", objNameList);
        //    return bExcuteStatus;
        //}

        //public bool MakeACollectionObjectNameRefList()
        //{
        //    NrkSdk.SetStep("Make a Collection Object Name Ref List");
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Collection Object Name List", objNameList);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool AppendTwoCollectionObjectNameRefLists()
        //{

        //    NrkSdk.SetStep("Append two Collection Object Name Ref Lists");
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Collection Object Name List A", objNameList);
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Collection Object Name List B", objNameList);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.GetCollectionObjectNameRefListArgHelper("Resultant Collection Object Name List(A+B)", objNameList);
        //    return bExcuteStatus;
        //}

        public bool AddACollectionObjectNameToARefList(string argName, string scol, string objName, ref object _objNameList)
        {
            NrkSdk.SetStep("Add a Collection Object Name to a Ref List");
            NrkSdk.SetCollectionObjectNameRefListArg("Collection Object Name List", ref _objNameList);
            NrkSdk.SetCollectionObjectNameArg(argName, scol, objName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //public bool MakeACollectionObjectNameRefListFromAllGroupsInACollection()
        //{

        //    NrkSdk.SetStep("Make a Collection Object Name Ref List from all Groups in a Collection");
        //    NrkSdk.SetCollectionNameArg("Collection Name", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.GetCollectionObjectNameRefListArgHelper("Collection Object Name List", objNameList);
        //    return bExcuteStatus;
        //}

        //public bool MakeACollectionInstrumentReferenceList()
        //{
        //    NrkSdk.SetStep("Make a Collection Instrument Reference List");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    CStringArray instIdList;
        //    SDKHelper helper(NrkSdk);
        //    helper.GetColInstIdRefListArgHelper("Resultant Collection Instrument Reference List", instIdList);
        //    return bExcuteStatus;
        //}

        //public bool AddACollectionInstrumentToARefList()
        //{
        //    NrkSdk.SetStep("Add a Collection Instrument to a Ref List");
        //    CStringArray instObjList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetColInstIdRefListArgHelper("Collection Instrument Reference List", instObjList);
        //    NrkSdk.SetColInstIdArg("Collection Instrument To Add", "", );
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool MakeACollectionInstrumentReferenceListRuntimeSelect()
        //{
        //    NrkSdk.SetStep("Make a Collection Instrument Reference List- Runtime Select");
        //    NrkSdk.SetStringArg("User Prompt", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    CStringArray instIdList;
        //    SDKHelper helper(NrkSdk);
        //    helper.GetColInstIdRefListArgHelper("Resultant Collection Instrument Reference List", instIdList);
        //    return bExcuteStatus;
        //}

        //public bool MakeARelationshipReferenceListWildCardSelection()
        //{
        //    NrkSdk.SetStep("Make a Relationship Reference List- WildCard Selection");
        //    NrkSdk.SetStringArg("Collection Wildcard Criteria", "*");
        //    NrkSdk.SetStringArg("Relationship Wildcard Criteria", "*");
        //    NrkSdk.NOT_SUPPORTED("Resultant Relationship Reference List");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool MakeAnEventReferenceListWildCardSelection()
        //{
        //    NrkSdk.SetStep("Make an Event Reference List- WildCard Selection");
        //    NrkSdk.SetStringArg("Collection Wildcard Criteria", "*");
        //    NrkSdk.SetStringArg("Event Wildcard Criteria", "*");
        //    NrkSdk.NOT_SUPPORTED("Resultant Event Reference List");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //        public bool MakeACollectionInstrumentIDFromACollectionAndAnInteger()
        //        {
        //            NrkSdk.SetStep("Make a Collection Instrument ID from a Collection and an Integer");
        //            NrkSdk.SetCollectionNameArg("Collection Name", "");
        //            NrkSdk.SetIntegerArg("Instrument", 0);
        //            bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            BSTR sCol = NULL;
        //            long instId;
        //            NrkSdk.GetColInstIdArg("Instrument ID", &sCol, &instId);
        //            CString colName = sCol;
        //::SysFreeString(sCol);

        //            return bExcuteStatus;
        //        }

        //        public bool MakeACollectionInstrumentIDRuntimeSelect()
        //        {
        //            NrkSdk.SetStep("Make a Collection Instrument ID - Runtime Select");
        //            NrkSdk.SetStringArg("User Prompt", "");
        //            bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            BSTR sCol = NULL;
        //            long instId;
        //            NrkSdk.GetColInstIdArg("Instrument ID", &sCol, &instId);
        //            CString colName = sCol;
        //::SysFreeString(sCol);
        //            return bExcuteStatus;
        //        }

        //public bool MakeACollectionVectorGroupNameRefListRuntimeSelect()
        //{
        //    NrkSdk.SetStep("Make a Collection Vector Group Name Ref List - Runtime Select");
        //    NrkSdk.SetStringArg("User Prompt", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    CStringArray vgNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.GetCollectionVectorGroupNameRefListArgHelper("Resultant Collection Vector Group Name Reference List", vgNameList);
        //    return bExcuteStatus;
        //}

        //        public bool MakeACollectionMachineIDFromACollectionAndAnInteger()
        //        {
        //            NrkSdk.SetStep("Make a Collection Machine ID from a Collection and an Integer");
        //            NrkSdk.SetCollectionNameArg("Collection Name", "");
        //            NrkSdk.SetIntegerArg("Machine", 0);
        //            bool bExcuteStatus = NrkSdk.ExecuteStep();
        //            BSTR sCol = NULL;
        //            long machineId;
        //            NrkSdk.GetColMachineIdArg("Machine ID", &sCol, &machineId);
        //            CString colName = sCol;
        //::SysFreeString(sCol);
        //            return bExcuteStatus;
        //        }

        //public bool MakeAReportRefListRuntimeSelect()
        //{
        //    NrkSdk.SetStep("Make a Report Ref List - Runtime Select");
        //    NrkSdk.SetStringArg("User Prompt", "");
        //    NrkSdk.NOT_SUPPORTED("Report List");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool MakeAReportRefListFromACollection()
        //{
        //    NrkSdk.SetStep("Make a Report Ref List from a Collection");
        //    NrkSdk.SetCollectionNameArg("Collection Name", "");
        //    NrkSdk.NOT_SUPPORTED("Report List");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool MakeAPictureNameRefList()
        //{

        //    NrkSdk.SetStep("Make a Picture Name Ref List");
        //    NrkSdk.NOT_SUPPORTED("Picture Name List");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool MakeAPictureNameRefListRuntimeSelect()
        //{
        //    NrkSdk.SetStep("Make a Picture Name Ref List - Runtime Select");
        //    NrkSdk.SetStringArg("User Prompt", "");
        //    NrkSdk.NOT_SUPPORTED("Picture Name List");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool MakeATransformFromDoublesFixedXYZ()
        //{
        //    NrkSdk.SetStep("Make a Transform from Doubles (Fixed XYZ)");
        //    NrkSdk.SetDoubleArg("X", 0.000000);
        //    NrkSdk.SetDoubleArg("Y", 0.000000);
        //    NrkSdk.SetDoubleArg("Z", 0.000000);
        //    NrkSdk.SetDoubleArg("Rx (Roll)", 0.000000);
        //    NrkSdk.SetDoubleArg("Ry (Pitch)", 0.000000);
        //    NrkSdk.SetDoubleArg("Rz (Yaw)", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();

        //    double T[4][4];
        //    SDKHelper helper(NrkSdk);
        //helper.GetTransformArgHelper("Resultant Transform", T);
        //    return bExcuteStatus;
        //}

        //    public bool MakeAWorldTransformOperatorFromTransformAndScale()
        //    {
        //        NrkSdk.SetStep("Make a World Transform Operator (from Transform and Scale)");
        //        double T[4][4];
        //	T[0][0] = 1.000000; 	T[0][1] = 0.000000; 	T[0][2] = 0.000000; 	T[0][3] = 0.000000; 
        //	T[1][0] = 0.000000; 	T[1][1] = 1.000000; 	T[1][2] = 0.000000; 	T[1][3] = 0.000000; 
        //	T[2][0] = 0.000000; 	T[2][1] = 0.000000; 	T[2][2] = 1.000000; 	T[2][3] = 0.000000; 
        //	T[3][0] = 0.000000; 	T[3][1] = 0.000000; 	T[3][2] = 0.000000; 	T[3][3] = 1.000000; 
        //	SDKHelper helper(NrkSdk);
        //    helper.SetTransformArgHelper("Transform", T);
        //	NrkSdk.SetDoubleArg("Scale", 1.000000);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    double T[4][4];
        //double scale;
        //    SDKHelper helper(NrkSdk);
        //    helper.GetWorldTransformArgHelper("World Transform Operator", T, scale);

        //return bExcuteStatus;
        //    }


        //public bool MakeATransformFromDoublesMatrixElements()
        //{
        //    NrkSdk.SetStep("Make a Transform from Doubles (Matrix Elements)");
        //    NrkSdk.SetDoubleArg("r0c0", 0.000000);
        //    NrkSdk.SetDoubleArg("r0c1", 0.000000);
        //    NrkSdk.SetDoubleArg("r0c2", 0.000000);
        //    NrkSdk.SetDoubleArg("r0c3", 0.000000);
        //    NrkSdk.SetDoubleArg("r1c0", 0.000000);
        //    NrkSdk.SetDoubleArg("r1c1", 0.000000);
        //    NrkSdk.SetDoubleArg("r1c2", 0.000000);
        //    NrkSdk.SetDoubleArg("r1c3", 0.000000);
        //    NrkSdk.SetDoubleArg("r2c0", 0.000000);
        //    NrkSdk.SetDoubleArg("r2c1", 0.000000);
        //    NrkSdk.SetDoubleArg("r2c2", 0.000000);
        //    NrkSdk.SetDoubleArg("r2c3", 0.000000);
        //    NrkSdk.SetDoubleArg("r3c0", 0.000000);
        //    NrkSdk.SetDoubleArg("r3c1", 0.000000);
        //    NrkSdk.SetDoubleArg("r3c2", 0.000000);
        //    NrkSdk.SetDoubleArg("r3c3", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    double T[4][4];
        //SDKHelper helper(NrkSdk);
        //helper.GetTransformArgHelper("Resultant Transform", T);
        //    return bExcuteStatus;
        //}


        //        public bool GetWorkingTransformOfObjectFixedXYZ()
        //        {
        //            NrkSdk.SetStep("Get Working Transform of Object (Fixed XYZ)");
        //            NrkSdk.SetCollectionObjectNameArg("Object Name", "", "");
        //            double T[4][4];
        //SDKHelper helper(NrkSdk);
        //        helper.GetTransformArgHelper("Transform", T);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep(); return bExcuteStatus;
        //}

        //    public bool DecomposeTransformIntoDoublesFixedXYZ()
        //    {
        //        NrkSdk.SetStep("Decompose Transform into Doubles (Fixed XYZ)");
        //        double T[4][4];
        //	T[0][0] = 1.000000; 	T[0][1] = 0.000000; 	T[0][2] = 0.000000; 	T[0][3] = 0.000000; 
        //	T[1][0] = 0.000000; 	T[1][1] = 1.000000; 	T[1][2] = 0.000000; 	T[1][3] = 0.000000; 
        //	T[2][0] = 0.000000; 	T[2][1] = 0.000000; 	T[2][2] = 1.000000; 	T[2][3] = 0.000000; 
        //	T[3][0] = 0.000000; 	T[3][1] = 0.000000; 	T[3][2] = 0.000000; 	T[3][3] = 1.000000; 
        //	SDKHelper helper(NrkSdk);
        //    helper.SetTransformArgHelper("Input Transform", T);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();


        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("X", &value);

        //DOUBLE value;
        //    NrkSdk.GetDoubleArg("Y", &value);

        //DOUBLE value;
        //    NrkSdk.GetDoubleArg("Z", &value);

        //DOUBLE value;
        //    NrkSdk.GetDoubleArg("Rx (Roll)", &value);

        //DOUBLE value;
        //    NrkSdk.GetDoubleArg("Ry (Pitch)", &value);

        //DOUBLE value;
        //    NrkSdk.GetDoubleArg("Rz (Yaw)", &value);

        //return bExcuteStatus;
        //    }

        //public bool DecomposeTransformIntoVectorsFixedXYZ()
        //{
        //    NrkSdk.SetStep("Decompose Transform into Vectors (Fixed XYZ)");
        //    double T[4][4];
        //	T[0][0] = 1.000000; 	T[0][1] = 0.000000; 	T[0][2] = 0.000000; 	T[0][3] = 0.000000; 
        //	T[1][0] = 0.000000; 	T[1][1] = 1.000000; 	T[1][2] = 0.000000; 	T[1][3] = 0.000000; 
        //	T[2][0] = 0.000000; 	T[2][1] = 0.000000; 	T[2][2] = 1.000000; 	T[2][3] = 0.000000; 
        //	T[3][0] = 0.000000; 	T[3][1] = 0.000000; 	T[3][2] = 0.000000; 	T[3][3] = 1.000000; 
        //	SDKHelper helper(NrkSdk);
        //helper.SetTransformArgHelper("Input Transform", T);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();

        //DOUBLE xVal;
        //DOUBLE yVal;
        //DOUBLE zVal;
        //NrkSdk.GetVectorArg("Position in Working", &xVal, &yVal, &zVal);

        //DOUBLE xVal;
        //DOUBLE yVal;
        //DOUBLE zVal;
        //NrkSdk.GetVectorArg("Orientation in Working", &xVal, &yVal, &zVal);
        //return bExcuteStatus;

        //    }

        //    public bool DecomposeTransformIntoVectorsOriginAndAxes()
        //{

        //    NrkSdk.SetStep("Decompose Transform into Vectors (Origin and Axes)");
        //    double T[4][4];
        //	T[0][0] = 1.000000; 	T[0][1] = 0.000000; 	T[0][2] = 0.000000; 	T[0][3] = 0.000000; 
        //	T[1][0] = 0.000000; 	T[1][1] = 1.000000; 	T[1][2] = 0.000000; 	T[1][3] = 0.000000; 
        //	T[2][0] = 0.000000; 	T[2][1] = 0.000000; 	T[2][2] = 1.000000; 	T[2][3] = 0.000000; 
        //	T[3][0] = 0.000000; 	T[3][1] = 0.000000; 	T[3][2] = 0.000000; 	T[3][3] = 1.000000; 
        //	SDKHelper helper(NrkSdk);
        //helper.SetTransformArgHelper("Transform", T);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();
        //DOUBLE xVal;
        //DOUBLE yVal;
        //DOUBLE zVal;
        //NrkSdk.GetVectorArg("Origin", &xVal, &yVal, &zVal);

        //DOUBLE xVal;
        //DOUBLE yVal;
        //DOUBLE zVal;
        //NrkSdk.GetVectorArg("X Axis", &xVal, &yVal, &zVal);

        //DOUBLE xVal;
        //DOUBLE yVal;
        //DOUBLE zVal;
        //NrkSdk.GetVectorArg("Y Axis", &xVal, &yVal, &zVal);

        //DOUBLE xVal;
        //DOUBLE yVal;
        //DOUBLE zVal;
        //NrkSdk.GetVectorArg("Z Axis", &xVal, &yVal, &zVal);
        //return bExcuteStatus;
        //    } 

        //    public bool DecomposeTransformIntoDoublesMatrixElements()
        //{
        //    NrkSdk.SetStep("Decompose Transform into Doubles (Matrix Elements)");
        //    double T[4][4];
        //	T[0][0] = 1.000000; 	T[0][1] = 0.000000; 	T[0][2] = 0.000000; 	T[0][3] = 0.000000; 
        //	T[1][0] = 0.000000; 	T[1][1] = 1.000000; 	T[1][2] = 0.000000; 	T[1][3] = 0.000000; 
        //	T[2][0] = 0.000000; 	T[2][1] = 0.000000; 	T[2][2] = 1.000000; 	T[2][3] = 0.000000; 
        //	T[3][0] = 0.000000; 	T[3][1] = 0.000000; 	T[3][2] = 0.000000; 	T[3][3] = 1.000000; 
        //	SDKHelper helper(NrkSdk);
        //helper.SetTransformArgHelper("Transform", T);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();
        //DOUBLE value;
        //NrkSdk.GetDoubleArg("r0c0", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("r0c1", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("r0c2", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("r0c3", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("r1c0", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("r1c1", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("r1c2", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("r1c3", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("r2c0", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("r2c1", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("r2c2", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("r2c3", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("r3c0", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("r3c1", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("r3c2", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("r3c3", &value);

        //return bExcuteStatus;
        //    }


        //    public bool DecomposeWorldTransformOperatorIntoDoublesFixedXYZinWorld()
        //{
        //    NrkSdk.SetStep("Decompose World Transform Operator into Doubles (Fixed XYZ in World)");
        //    double T[4][4];
        //	double scale;
        //T[0][0] = 1.000000; 	T[0][1] = -0.000000; 	T[0][2] = 0.000000; 	T[0][3] = 0.000000; 
        //	T[1][0] = 0.000000; 	T[1][1] = 1.000000; 	T[1][2] = -0.000000; 	T[1][3] = 0.000000; 
        //	T[2][0] = 0.000000; 	T[2][1] = 0.000000; 	T[2][2] = 1.000000; 	T[2][3] = 0.000000; 
        //	T[3][0] = 0.000000; 	T[3][1] = 0.000000; 	T[3][2] = 0.000000; 	T[3][3] = 1.000000; 
        //	scale = 1.000000;
        //	SDKHelper helper(NrkSdk);
        //helper.SetWorldTransformArgHelper("Input World Transform Operator", T, scale);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();
        //DOUBLE value;
        //NrkSdk.GetDoubleArg("X", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("Y", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("Z", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("Rx (Roll)", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("Ry (Pitch)", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("Rz (Yaw)", &value);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("Scale", &value);

        //return bExcuteStatus;
        //    } 

        //    public bool DecomposeWorldTransformOperatorIntoVectorsFixedXYZinorld()
        //{
        //    NrkSdk.SetStep("Decompose World Transform Operator into Vectors (Fixed XYZ in World)");
        //    double T[4][4];
        //	double scale;
        //T[0][0] = 1.000000; 	T[0][1] = -0.000000; 	T[0][2] = 0.000000; 	T[0][3] = 0.000000; 
        //	T[1][0] = 0.000000; 	T[1][1] = 1.000000; 	T[1][2] = -0.000000; 	T[1][3] = 0.000000; 
        //	T[2][0] = 0.000000; 	T[2][1] = 0.000000; 	T[2][2] = 1.000000; 	T[2][3] = 0.000000; 
        //	T[3][0] = 0.000000; 	T[3][1] = 0.000000; 	T[3][2] = 0.000000; 	T[3][3] = 1.000000; 
        //	scale = 1.000000;
        //	SDKHelper helper(NrkSdk);
        //helper.SetWorldTransformArgHelper("Input World Transform Operator", T, scale);

        //bool bExcuteStatus = NrkSdk.ExecuteStep();
        //DOUBLE xVal;
        //DOUBLE yVal;
        //DOUBLE zVal;
        //NrkSdk.GetVectorArg("Position in Working", &xVal, &yVal, &zVal);

        //DOUBLE xVal;
        //DOUBLE yVal;
        //DOUBLE zVal;
        //NrkSdk.GetVectorArg("Orientation in Working", &xVal, &yVal, &zVal);

        //DOUBLE value;
        //NrkSdk.GetDoubleArg("Scale", &value);
        //    return bExcuteStatus;
        //    }


        //    public bool MakeAVectorFromDoubles()
        //{
        //    NrkSdk.SetStep("Make a Vector from Doubles");
        //    NrkSdk.SetDoubleArg("X", 0.000000);
        //    NrkSdk.SetDoubleArg("Y", 0.000000);
        //    NrkSdk.SetDoubleArg("Z", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    DOUBLE xVal;
        //    DOUBLE yVal;
        //    DOUBLE zVal;
        //    NrkSdk.GetVectorArg("Resultant Vector", &xVal, &yVal, &zVal);

        //    return bExcuteStatus;
        //}

        //public bool DecomposeVectorIntoDoubles()
        //{
        //    NrkSdk.SetStep("Decompose Vector into Doubles");
        //    NrkSdk.SetVectorArg("Input Vector", 0.000000, 0.000000, 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("X", &value);

        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Y", &value);

        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Z", &value);
        //    return bExcuteStatus;
        //}

        //public bool SplitStringIntoTwoStrings()
        //{
        //    NrkSdk.SetStep("Split String into Two Strings");
        //    NrkSdk.SetStringArg("Input String", "");
        //    NrkSdk.SetIntegerArg("Dividing Character Index", 0);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    BSTR sValue = NULL;
        //    NrkSdk.GetStringArg("First String", &sValue);
        //    CString name = sValue;
        //::SysFreeString(sValue);

        //    BSTR sValue = NULL;
        //    NrkSdk.GetStringArg("Second String", &sValue);
        //    CString name = sValue;
        //::SysFreeString(sValue);
        //    return bExcuteStatus;
        //}

        //public bool MakeANormalizedVector()
        //{
        //    NrkSdk.SetStep("Make a Normalized Vector");
        //    NrkSdk.SetVectorArg("Input Vector", 0.000000, 0.000000, 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    DOUBLE xVal;
        //    DOUBLE yVal;
        //    DOUBLE zVal;
        //    NrkSdk.GetVectorArg("Resultant Vector", &xVal, &yVal, &zVal);

        //    return bExcuteStatus;
        //}

        //public bool ConvertToEulerAnglesFromFixedAngles()
        //{
        //    NrkSdk.SetStep("Convert to Euler Angles from Fixed Angles");
        //    double T[4][4];
        //	T[0][0] = 1.000000; 	T[0][1] = 0.000000; 	T[0][2] = 0.000000; 	T[0][3] = 0.000000; 
        //	T[1][0] = 0.000000; 	T[1][1] = 1.000000; 	T[1][2] = 0.000000; 	T[1][3] = 0.000000; 
        //	T[2][0] = 0.000000; 	T[2][1] = 0.000000; 	T[2][2] = 1.000000; 	T[2][3] = 0.000000; 
        //	T[3][0] = 0.000000; 	T[3][1] = 0.000000; 	T[3][2] = 0.000000; 	T[3][3] = 1.000000; 
        //	SDKHelper helper(NrkSdk);
        //helper.SetTransformArgHelper("Input Transform (Fixed Angles)", T);
        //	NrkSdk.NOT_SUPPORTED("Pick Euler Angle Type");
        //bool bExcuteStatus = NrkSdk.ExecuteStep();
        //double T[4][4];
        //SDKHelper helper(NrkSdk);
        //helper.GetTransformArgHelper("Output Transform of Euler Angles", T);

        //return bExcuteStatus;
        //    }


        //    public bool MakeProjectionOptions()
        //{
        //    NrkSdk.SetStep("Make Projection Options");
        //    NrkSdk.NOT_SUPPORTED("Output Type");
        //    NrkSdk.SetBoolArg("Ignore Edge Projections", FALSE);
        //    NrkSdk.SetBoolArg("Probe Offsets - Override Target Values?", FALSE);
        //    NrkSdk.SetDoubleArg("Probe Offsets - Override Value", 0.000000);
        //    NrkSdk.SetDoubleArg("Extra Material Thickness", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool MakeAxisIdentifierFromString()
        //{
        //    NrkSdk.SetStep("Make Axis Identifier from String");
        //    NrkSdk.SetStringArg("String Input", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool GetLastInstrumentIndex()
        //{
        //    NrkSdk.SetStep("Get Last Instrument Index");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    long value;
        //    NrkSdk.GetIntegerArg("Instrument ID", &value);
        //    BSTR sCol = NULL;
        //    long instId;
        //    NrkSdk.GetColInstIdArg("Instrument ID", &sCol, &instId);
        //    CString colName = sCol;
        //::SysFreeString(sCol);
        //    return bExcuteStatus;
        //}

        public bool RenameInstrument(string _sCollection, int _iInsID, string _sInsNewName)
        {
            NrkSdk.SetStep("Rename Instrument");
            NrkSdk.SetColInstIdArg("Instrument ID", _sCollection, _iInsID);
            NrkSdk.SetStringArg("New Name", _sInsNewName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }
        public bool GetInstrumentIDFromName(string _sName, ref string _sCol, ref int _iID)
        {
            NrkSdk.SetStep("Get Instrument ID from Name");
            NrkSdk.SetStringArg("Name", _sName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetColInstIdArg("Instrument ID", _sCol, _iID);
            return bExcuteStatus;
        }


        public bool GetInstrumentModel(string _sCollection, int _iInsID, ref string _sModel)
        {
            NrkSdk.SetStep("Get Instrument Model");
            NrkSdk.SetColInstIdArg("Instrument ID", _sCollection, _iInsID);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetStringArg("Model", _sModel);
            return bExcuteStatus;
        }


        public bool MoveInstrumentToAnotherCollection(string _sCollection, int _iInsID, string _sNewCollection)
        {
            NrkSdk.SetStep("Move Instrument to Another Collection");
            NrkSdk.SetColInstIdArg("Instrument ID", _sCollection, _iInsID);
            NrkSdk.SetCollectionNameArg("Collection Name", _sNewCollection);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool SaveInstrumentConfiguration(string _sCollection, int _iInsID,
            string _sConfigfilePath)
        {
            NrkSdk.SetStep("Save Instrument Configuration");
            NrkSdk.SetColInstIdArg("Instrument ID", _sCollection, _iInsID);
            NrkSdk.SetFilePathArg("Configuration File", _sConfigfilePath, false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool LoadInstrumentConfiguration(string _sCollection, int _iInsID, string _sConfigfilePath)
        {
            NrkSdk.SetStep("Load Instrument Configuration");
            NrkSdk.SetColInstIdArg("Instrument ID", _sCollection, _iInsID);
            NrkSdk.SetFilePathArg("Configuration File", _sConfigfilePath, false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool MeasureSinglePointHere(string _sInsCollection, int _iInsID,
            string _sPntCollection, string _sPntGrp, string _sPntName)
        {
            NrkSdk.SetStep("Measure Single Point Here");
            NrkSdk.SetColInstIdArg("Instrument ID", _sInsCollection, _iInsID);
            NrkSdk.SetPointNameArg("Target ID", _sPntCollection, _sPntGrp, _sPntName);
            NrkSdk.SetBoolArg("Measure Immediately", true);
            NrkSdk.SetFilePathArg("HTML Prompt File (optional)", "", false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool PointAtTarget(string _sInsCollection, int _iInsID,
             string _sTarPntCollection, string _sPntTarGrp, string _sPntTarName)
        {
            NrkSdk.SetStep("Point At Target");
            NrkSdk.SetColInstIdArg("Instrument ID", _sInsCollection, _iInsID);
            NrkSdk.SetPointNameArg("Target ID", _sTarPntCollection, _sPntTarGrp, _sPntTarName);
            NrkSdk.SetFilePathArg("HTML Prompt File (optional)", "", false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        //public bool BuildTarget()
        //{
        //    NrkSdk.SetStep("'Build' Target");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    NrkSdk.SetPointNameArg("Output Target Name", "", "", "");
        //    NrkSdk.SetPointNameArg("Nominal Point", "", "", "");
        //    NrkSdk.NOT_SUPPORTED("Tolerance");
        //    NrkSdk.SetFilePathArg("HTML Prompt File (optional)", "", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        public bool MeasureExistingSinglePoint(string _sInsCollection, int _iInsID,
            string _sTarPntCollection, string _sPntTarGrp, string _sPntTarName,
            string _sNewPntCollection, string _sNewPntGrp, string _sNewPntName,
            ref string _sResPntCol, ref string _sResPntGrp, ref string _sResPntName)
        {
            NrkSdk.SetStep("Measure Existing Single Point");
            NrkSdk.SetColInstIdArg("Instrument ID", _sInsCollection, _iInsID);
            NrkSdk.SetPointNameArg("Existing Target ID", _sTarPntCollection, _sPntTarGrp, _sPntTarName);
            NrkSdk.SetCollectionObjectNameArg("Group name for new point", _sNewPntCollection, _sNewPntGrp);
            NrkSdk.SetBoolArg("Measure Immediately", false);
            NrkSdk.SetFilePathArg("HTML Prompt File (optional)", "", false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();

            NrkSdk.GetPointNameArg("Resulting Point Name", _sResPntCol, _sResPntGrp, _sResPntName);

            return bExcuteStatus;
        }

        //public bool MeasureExistingSinglePointManualGuide)()
        //    {
        //NrkSdk.SetStep("Measure Existing Single Point (Manual Guide)");
        //	NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //	NrkSdk.SetPointNameArg("Existing Target ID", "", "", "");
        //	NrkSdk.SetCollectionObjectNameArg("Group name for new point", "", "");
        //	NrkSdk.SetBoolArg("Measure Immediately", FALSE);
        //	NrkSdk.SetFilePathArg("HTML Prompt File (optional)", "", FALSE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();
        //BSTR sCol = NULL;
        //BSTR sGrp = NULL;
        //BSTR sTarg = NULL;
        //NrkSdk.GetPointNameArg("Resulting Point Name", &sCol, &sGrp, &sTarg);
        //CString collection = sCol;
        //CString group = sGrp;
        //CString target = sTarg;
        //::SysFreeString(sCol);
        //::SysFreeString(sGrp);
        //::SysFreeString(sTarg);
        //return bExcuteStatus;
        //    } 

        //    public bool MeasureExistingSinglePointAndCompare()
        //{
        //    NrkSdk.SetStep("Measure Existing Single Point and Compare");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    NrkSdk.SetPointNameArg("Existing Target ID", "", "", "");
        //    NrkSdk.SetCollectionObjectNameArg("Group name for new point", "", "");
        //    NrkSdk.SetBoolArg("Measure Immediately", FALSE);
        //    NrkSdk.SetFilePathArg("HTML Prompt File (optional)", "", FALSE);
        //    NrkSdk.SetDoubleArg("Tolerance (0.0 for none)", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    DOUBLE xVal;
        //    DOUBLE yVal;
        //    DOUBLE zVal;
        //    NrkSdk.GetVectorArg("Vector Representation", &xVal, &yVal, &zVal);

        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("X Value", &value);

        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Y Value", &value);

        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Z Value", &value);

        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Magnitude", &value);

        //    BSTR sCol = NULL;
        //    BSTR sGrp = NULL;
        //    BSTR sTarg = NULL;
        //    NrkSdk.GetPointNameArg("Resulting Point Name", &sCol, &sGrp, &sTarg);
        //    CString collection = sCol;
        //    CString group = sGrp;
        //    CString target = sTarg;
        //::SysFreeString(sCol);
        //::SysFreeString(sGrp);
        //::SysFreeString(sTarg);
        //    return bExcuteStatus;
        //}

        public bool StopActiveMeasurementMode(string _sInsCollection, int _iInsID)
        {
            NrkSdk.SetStep("Stop Active Measurement Mode");
            NrkSdk.SetColInstIdArg("Instrument ID", _sInsCollection, _iInsID);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool AddNewInstrument(string _sInstrumentType, ref string _sInsCollection, ref int _iInsID)
        {
            NrkSdk.SetStep("Add New Instrument");
            // Available options: 
            // "Faro Vantage", "Faro Tracker", "Faro Ion Tracker", "SMX Tracker 4000,4500", "Leica Tracker TP-LINK", 
            // "Leica emScon Tracker (LT500-800 Series)", "Leica emScon Absolute Tracker (AT901 Series)", "Leica emScon AT401", "Leica emScon AT402", "API Tracker II", 
            // "API Tracker III", "API OmniTrac", "API Tracker Device Interface", "API Radian", "API OmniTrac2", 
            // "API Laser Rail", "Boeing Laser Tracker", "Chesapeake 3000 Laser Tracker", "Metris Laser Radar MV200", "Nikon Metrology Metris Laser Radar MV300", 
            // "Metris Laser Radar (CLRICx)", "Metris CLR 100 Laser Radar", "Boeing TaLLS Scanner", "Leica TPS Total Station (2003,5000,5005)", "Leica TDA5005 Total Station (GeoCOM)", 
            // "Leica Total Station TC2000, TC2002", "Leica Nova MS50 Total Station", "Leica TDRA6000 Total Station", "Sokkia SETX Total Station", "Sokkia Net05X Total Station", 
            // "Sokkia Net05AX Total Station", "Sokkia Net-1 Total Station", "Sokkia Net-2 Total Station", "FARO Arm", "FARO Arm G04", 
            // "FARO Arm S08", "FARO Arm G08", "FARO Arm S12", "FARO Arm G12", "FARO Arm G04-05 (7dof)", 
            // "FARO Arm G08-05 (7dof)", "FARO Arm G12-05 (7dof)", "FARO Arm USB 4 ft.", "FARO Arm USB 6 ft.", "FARO Arm USB 8 ft. & Quantum", 
            // "FARO Arm USB 10 ft.", "FARO Arm USB 12 ft.", "FARO Arm USB 4 ft. (7 dof)", "FARO Arm USB 6 ft. (7 dof)", "FARO Arm USB 8 ft. & Quantum (7 dof)", 
            // "FARO Arm USB 10 ft. (7 dof)", "FARO Arm USB 12 ft. (7 dof)", "FARO Edge Arm 9 ft. (7 dof)", "CimCore Arm 1024", "CimCore Arm 1028", 
            // "CimCore Arm 1030", "CimCore Arm 2200", "CimCore Arm 2500", "CimCore Arm 6DOF: 3012i, 5012, 1.2m", "CimCore Arm 6DOF: 3018i, 5018, 1.8m", 
            // "CimCore Arm 6DOF: 3024i, 5024, 2.4m", "CimCore Arm 6DOF: 3028i, 5028, 2.8m", "CimCore Arm 6DOF: 3036i, 5036, 3.6m", "CimCore Arm 7DOF: 5012Sc, 3012, 1.2m", "CimCore Arm 7DOF: 5018Sc, 3018, 1.8m", 
            // "CimCore Arm 7DOF: 5030Sc, 3030, 3.0m", "CimCore Arm 7DOF: 5028Sc, 3028, 2.8m", "CimCore Arm 7DOF: 5024Sc, 3024, 2.4m", "CimCore Arm 7DOF: 5036Sc, 3036, 3.6m", "CimCore Arm 7DOF: 5112Sc, 1.2m", 
            // "CimCore Arm 7DOF: 5118Sc, 1.8m", "CimCore Arm 7DOF: 5130Sc, 3.0m", "CimCore Arm 7DOF: 5128Sc, 2.8m", "CimCore Arm 7DOF: 5124Sc, 2.4m", "CimCore Arm 7DOF: 5136Sc, 3.6m", 
            // "CimCore Arm 6DOF: 5112, 1.2m", "CimCore Arm 6DOF: 5118, 1.8m", "CimCore Arm 6DOF: 5130, 3.0m", "CimCore Arm 6DOF: 5128, 2.8m", "CimCore Arm 6DOF: 5124, 2.4m", 
            // "CimCore Arm 6DOF: 5136, 3.6m", "Romer Multi-Gage", "Romer Absolute 7x20SI/SE", "Romer Absolute 7x25SI/SE", "Romer Absolute 7x30SI/SE", 
            // "Romer Absolute 7x35SI/SE", "Romer Absolute 7x40SI/SE", "Romer Absolute 7x45SI/SE", "Romer Absolute 7315", "Romer Absolute 7x20", 
            // "Romer Absolute 7x25", "Romer Absolute 7x30", "Romer Absolute 7x35", "Romer Absolute 7x40", "Romer Absolute 7x45", 
            // "Metris MCA Arm", "Romer Sigma Arm 2022", "Sandia National Labs Arm", "Axxis 6-100 Arm (2.6m 6 dof)", "Axxis 7-100 Arm Scanner (2.6m 7 dof)", 
            // "Axxis 7-100 Arm Probe (2.6m 7 dof)", "Axxis 6-200 Arm (3.2m 6 dof)", "Leica/Wild Theodolites T2000,T2002,T3000", "Leica TPS Theodolite (1800)", "Leica TPS Theodolite (5100)", 
            // "Zeiss ETh 2 Theodolite", "Kern E2 Theodolite", "Cubic KIT Theodolite", "GSI V-STARS Photogrammetry System", "AICON ProCam 3D Probe", 
            // "Metris K-Series (K-Scan & SpaceProbe)", "METRONOR Portable Measurement System", "Creaform Handy Probe", "Metris Surveyor", "Metris iGPS Network", 
            // "Metris iGPS Transmitter Simulator", "Metris Surveyor v2", "Metron Scanner", "Minolta VIVID 700 Scanner", "Minolta VIVID 900 Scanner", 
            // "Nivel 20 Two Axis Level", "Thommen HM30 Weather Station", "On-Trak Laser Line System (OT-4040, OT-6000)", "Davis Perception II Weather Station", "ScAlert Temperature Probe", 
            // "Ultrasonic Thickness Gauge (CL400)", "Imported Measurements with Uncertainty", "Virtek Laser Projector", "LPT Laser Projector", "Assembly Guidance Laser Projector", 
            // "LAP CAD-Pro Laser Projector", "SA Open Instrument", "SA Open Auxiliary Instrument", "Faro Scanner Photon/LS/Focus 3D", "Surphaser Scanner", 
            // "Leica Geosystems ScanStation P20", "Digital Network Level", "Creaform HandyScan 3D", "NDI OptoTrak", "Vicon Tracker", 
            // "AICON MoveInspect", "AICON DPA", "Leica TM6100A Theodolite", "Leica T1200 Total Station", "Leica TS15 Total Station", 
            // "Leica TS30 Total Station", "Ubisense RTLS", 
            NrkSdk.SetInstTypeNameArg("Instrument Type", _sInstrumentType);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            if (bExcuteStatus)
            {
                NrkSdk.GetColInstIdArg("Instrument Added (result)", ref _sInsCollection, ref _iInsID);
            }
            return bExcuteStatus;
        }


        public bool DeleteInstrument(string _sInsCollection, int _iInsID)
        {
            NrkSdk.SetStep("Delete Instrument");
            NrkSdk.SetColInstIdArg("Instrument ID", _sInsCollection, _iInsID);
            NrkSdk.SetBoolArg("Prompt user to confirm?", false);
            NrkSdk.SetBoolArg("Keep resulting points?", true);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //public bool DeleteMeasurements()
        //{
        //    NrkSdk.SetStep("Delete Measurements");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    NrkSdk.SetPointNameArg("Point Name", "", "", "");
        //    NrkSdk.SetBoolArg("Delete point if no measurements remain?", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool InitiateServoGuide()
        //{
        //    NrkSdk.SetStep("Initiate Servo-Guide");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    CStringArray ptNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetPointNameRefListArgHelper("Nominal Points", ptNameList);
        //    NrkSdk.SetStringArg("Group name suffix", "");
        //    NrkSdk.SetStringArg("Target name suffix", "");
        //    NrkSdk.SetDoubleArg("Tolerance", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        public bool WatchPointToPoint(string _sInsCollection, int _iInsID,
            string _sRefPointCollection, string _sRefPointGroup, string _sRefPointName,
            double _dTol,
            string _sMeasurementMode)
        {
            NrkSdk.SetStep("Watch Point To Point");
            NrkSdk.SetColInstIdArg("Instrument's ID", _sInsCollection, _iInsID);
            NrkSdk.SetPointNameArg("Reference Point", _sRefPointCollection, _sRefPointGroup, _sRefPointName);
            NrkSdk.SetDoubleArg("Tolerance", _dTol);
            NrkSdk.SetStringArg("Measurement Mode", _sMeasurementMode);
            NrkSdk.SetBoolArg("Pause MP Until Closed", false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        //public bool WatchPointToObjects()
        //{
        //    NrkSdk.SetStep("Watch Point To Objects");
        //    NrkSdk.SetColInstIdArg("Instrument's ID", "", );
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Objects to Consider", objNameList);
        //    NrkSdk.SetProjectionOptionsArg("Projection Options", "Object To Probe Vectors", FALSE, FALSE, 0.000000, FALSE, 0.000000);
        //    NrkSdk.SetDoubleArg("Tolerance", 0.000000);
        //    NrkSdk.SetStringArg("Measurement Mode", "");
        //    NrkSdk.SetBoolArg("Pause MP Until Closed", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool WatchClosestPoint()
        //{
        //    NrkSdk.SetStep("Watch Closest Point");
        //    NrkSdk.SetColInstIdArg("Instrument's ID", "", );
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Groups to Consider", objNameList);
        //    NrkSdk.SetDoubleArg("Tolerance", 0.000000);
        //    NrkSdk.SetStringArg("Measurement Mode", "");
        //    NrkSdk.SetBoolArg("Pause MP Until Closed", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        public bool WatchInstrument(string _sInsCollection, int _iInsID)
        {
            NrkSdk.SetStep("Watch Instrument");
            NrkSdk.SetColInstIdArg("Instrument's ID", _sInsCollection, _iInsID);
            NrkSdk.SetBoolArg("Pause MP Until Closed", false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool StartTheodoliteInterface(string _sInsCollection, int _iInsID, string _sTheodoliteType)
        {
            NrkSdk.SetStep("Start Theodolite Interface");
            NrkSdk.SetColInstIdArg("Instrument's ID", _sInsCollection, _iInsID);
            NrkSdk.SetStringArg("Theodolite Type (Must match Theodolite Manager Add Instrument type)", _sTheodoliteType);
            NrkSdk.SetIntegerArg("Comm Port", 0);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool StartInstrumentInterface(string _sInsCollection, int _iInsID, bool _bInitializeAtStartup, string _sIPAddress, bool _bSimulation)
        {
            NrkSdk.SetStep("Start Instrument Interface");
            NrkSdk.SetColInstIdArg("Instrument's ID", _sInsCollection, _iInsID);
            NrkSdk.SetBoolArg("Initialize at Startup", _bInitializeAtStartup);
            NrkSdk.SetStringArg("Device IP Address (optional)", _sIPAddress);
            NrkSdk.SetIntegerArg("Interface Type (0=default)", 0);
            NrkSdk.SetBoolArg("Run in Simulation", _bSimulation);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool StopInstrumentInterface(string _sInsCollection, int _iInsID)
        {
            NrkSdk.SetStep("Stop Instrument Interface");
            NrkSdk.SetColInstIdArg("Instrument's ID", _sInsCollection, _iInsID);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool VerifyInstrumentConnection(string _sInsCollection, int _iInsID, ref bool _bConnected)
        {
            NrkSdk.SetStep("Verify Instrument Connection");
            NrkSdk.SetColInstIdArg("Instrument's ID", _sInsCollection, _iInsID);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetBoolArg("Connected?", ref _bConnected);

            return bExcuteStatus;
        }


        public bool ConfigureAndMeasure(string _sInsCollection, int _iInsID,
            string _sPntCollection, string _sPntGroup, string _sPntName,
            string _sMeasmentMode, bool _bMeasureImmediately, bool _bWaitForCompletion)
        {
            NrkSdk.SetStep("Configure and Measure");
            NrkSdk.SetColInstIdArg("Instrument's ID", _sInsCollection, _iInsID);
            NrkSdk.SetPointNameArg("Target Name", _sPntCollection, _sPntGroup, _sPntName);
            NrkSdk.SetStringArg("Measurement Mode", _sMeasmentMode);
            NrkSdk.SetBoolArg("Measure Immediately", _bMeasureImmediately);
            NrkSdk.SetBoolArg("Wait for Completion", _bWaitForCompletion);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool Measure(string _sInsCollection, int _iInsID)
        {
            NrkSdk.SetStep("Measure");
            NrkSdk.SetColInstIdArg("Instrument's ID", _sInsCollection, _iInsID);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool ShowHideInstrumentInterface(string _sInsCollection, int _iInsID,
            bool _bMinimizeInterface, bool _bHideInterface)
        {
            NrkSdk.SetStep("Show/Hide Instrument Interface");
            NrkSdk.SetColInstIdArg("Instrument's ID", _sInsCollection, _iInsID);
            NrkSdk.SetBoolArg("Minimize Interface?", _bMinimizeInterface);
            NrkSdk.SetBoolArg("Hide Interface?", _bHideInterface);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool DockInstrumentInterface(string _sInsCollection, int _iInsID,
            bool _bDockInterface)
        {
            NrkSdk.SetStep("Dock Instrument Interface");
            NrkSdk.SetColInstIdArg("Instrument ID", _sInsCollection, _iInsID);
            NrkSdk.SetBoolArg("Dock Interface?", _bDockInterface);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool LocateInstrumentRefTieIn(string _sInsCollection, int _iInsID,
            string _sReferenceCollection, string _sReferenceGroup,
             string _sActualsCollection, string _sActualsGroup)
        {
            NrkSdk.SetStep("Locate Instrument (Ref. Tie-In)");
            NrkSdk.SetColInstIdArg("Instrument to Locate", _sInsCollection, _iInsID);
            NrkSdk.SetCollectionObjectNameArg("Reference Group Name", _sReferenceCollection, _sReferenceGroup);
            NrkSdk.SetCollectionObjectNameArg("Actuals Group Name (to be measured)", _sActualsCollection, _sActualsGroup);
            NrkSdk.SetDoubleArg("Tolerance", 0.000000);
            NrkSdk.SetBoolArg("Auto Survey", false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //public bool LocateInstrumentGroupToSurfaceQuickFit()
        //{
        //    NrkSdk.SetStep("Locate Instrument (Group to Surface Quick Fit)");
        //    NrkSdk.SetColInstIdArg("Instrument to Locate", "", );
        //    NrkSdk.SetCollectionObjectNameArg("Name of Measured Group", "", "");
        //    NrkSdk.SetCollectionObjectNameArg("Name of Group containing Surface Pts", "", "");
        //    NrkSdk.SetCollectionObjectNameArg("Surface to fit", "", "");
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Other Objects to Transform", objNameList);
        //    NrkSdk.SetDoubleArg("RMS Tolerance (0.0 for none)", 0.000000);
        //    NrkSdk.SetDoubleArg("Maximum Absolute Tolerance (0.0 for none)", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("RMS Error", &value);

        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Maximum Absolute Error", &value);


        //    return bExcuteStatus;
        //}


        //public bool LocateInstrumentsUSMN()
        //{
        //    NrkSdk.SetStep("Locate Instruments (USMN)");
        //    CStringArray instObjList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetColInstIdRefListArgHelper("Instruments to Locate", instObjList);
        //    NrkSdk.SetCollectionObjectNameArg("Nominals Group Name (blank for none)", "", "");
        //    NrkSdk.SetCollectionObjectNameArg("Output Group Name (to be established)", "", "");
        //    NrkSdk.SetBoolArg("AutoReject Outliers and Resolve", FALSE);
        //    // Available options: 
        //    // "No", "Yes", "On Tolerance Violation", 
        //    NrkSdk.SetShowUsmnDialogTypeArg("Show USMN Dialog", "");
        //    NrkSdk.SetDoubleArg("Max Acceptable RMS Error Value (0.0 for none)", 0.000000);
        //    NrkSdk.SetDoubleArg("Max Acceptable Error Value (0.0 for none)", 0.000000);
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Groups to be Excluded", objNameList);
        //    NrkSdk.SetBoolArg("Exclude Points Measured By Only One Instrument", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("RMS Error Value", &value);

        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Max Error Value", &value);
        //    return bExcuteStatus;
        //}


        public bool LocateInstrumentBestFitGroupToGroup(string _sRefCollection, string _sRefGroup,
            string _sCorrespondingCollection, string _sCorrespondingGroup,
            bool _bShowInterface, double _dRMSTol, double _dMaxiAbsTol, ref double[,] _sTransform, ref double _dScale)
        {
            NrkSdk.SetStep("Locate Instrument (Best Fit - Group to Group)");
            NrkSdk.SetCollectionObjectNameArg("Reference Group", _sRefCollection, _sRefGroup);
            NrkSdk.SetCollectionObjectNameArg("Corresponding Group", _sCorrespondingCollection, _sCorrespondingGroup);
            NrkSdk.SetBoolArg("Show Interface", _bShowInterface);
            NrkSdk.SetDoubleArg("RMS Tolerance (0.0 for none)", _dRMSTol);
            NrkSdk.SetDoubleArg("Maximum Absolute Tolerance (0.0 for none)", _dMaxiAbsTol);
            NrkSdk.SetBoolArg("Allow Scale", false);
            NrkSdk.SetBoolArg("Allow X", true);
            NrkSdk.SetBoolArg("Allow Y", true);
            NrkSdk.SetBoolArg("Allow Z", true);
            NrkSdk.SetBoolArg("Allow Rx", true);
            NrkSdk.SetBoolArg("Allow Ry", true);
            NrkSdk.SetBoolArg("Allow Rz", true);
            NrkSdk.SetFilePathArg("File Path for CSV Text Report (requires Show Interface = TRUE)", "", false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            if (true == bExcuteStatus)
            {
                Object vMatrix = null;
                NrkSdk.GetWorldTransformArg("Optimum Transform", ref vMatrix, ref _dScale);
                Array Amatrix = (Array)vMatrix;

                for (int i = 0; i <= 3; i++)
                {
                    for (int j = 0; j <= 3; j++)
                    {
                        double element;
                        element = (double)Amatrix.GetValue(i, j);
                        _sTransform[i, j] = element;
                    }
                }

            }
            //    double T[4][4];
            //SDKHelper helper(NrkSdk);
            //helper.GetTransformArgHelper("Transform in Working", T);

            //double T[4][4];
            //double scale;
            //SDKHelper helper(NrkSdk);
            //helper.GetWorldTransformArgHelper("Optimum Transform", T, scale);

            //DOUBLE value;
            //NrkSdk.GetDoubleArg("RMS Deviation", &value);

            //DOUBLE value;
            //NrkSdk.GetDoubleArg("Maximum Absolute Deviation", &value); 

            return bExcuteStatus;
        }


        public bool BestFitTransformationGrouptoGroup(string _RefCol, string _RefGroup, string _CorrespondingCol, string _CorrespondingGroup,
            bool bShowInterface, double dRMS, double dAbsTol, ref double[,] _sTransform)
        {
            NrkSdk.SetStep("Best Fit Transformation - Group to Group");
            NrkSdk.SetCollectionObjectNameArg("Reference Group", _RefCol, _RefGroup);
            NrkSdk.SetCollectionObjectNameArg("Corresponding Group", _CorrespondingCol, _CorrespondingGroup);
            NrkSdk.SetBoolArg("Show Interface", bShowInterface);
            NrkSdk.SetDoubleArg("RMS Tolerance (0.0 for none)", dRMS);
            NrkSdk.SetDoubleArg("Maximum Absolute Tolerance (0.0 for none)", dAbsTol);
            NrkSdk.SetBoolArg("Allow Scale", false);
            NrkSdk.SetBoolArg("Allow X", true);
            NrkSdk.SetBoolArg("Allow Y", true);
            NrkSdk.SetBoolArg("Allow Z", true);
            NrkSdk.SetBoolArg("Allow Rx", true);
            NrkSdk.SetBoolArg("Allow Ry", true);
            NrkSdk.SetBoolArg("Allow Rz", true);
            NrkSdk.SetFilePathArg("File Path for CSV Text Report (requires Show Interface = TRUE)", "", false);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            if (bExcuteStatus)
            {
                //double outScale;
                Object vMatrix = null;
                NrkSdk.GetTransformArg("Transform in Working", ref vMatrix);
                Array Amatrix = (Array)vMatrix;

                for (int i = 0; i <= 3; i++)
                {
                    for (int j = 0; j <= 3; j++)
                    {
                        double element;
                        element = (double)Amatrix.GetValue(i, j);
                        _sTransform[i, j] = element;
                    }
                }
                //                double 
                //NrkSdk.GetWorldTransformArg("Optimum Transform", ref Transform, ref  outScale);

                //NrkSdk.GetDoubleArg("RMS Deviation", &value);

                //        double AbsValue;
                //NrkSdk.GetDoubleArg("Maximum Absolute Deviation", &AbsValue);

                return true;
            }
            return bExcuteStatus;
        }


        public bool GetInstrumentTransform(string _sInsCollection, int _iInsID,
            string _sFrameCollection, string _sFrameName, ref object _TransformMatrix)
        {
            NrkSdk.SetStep("Get Instrument Transform");
            NrkSdk.SetColInstIdArg("Instrument ID", _sInsCollection, _iInsID);
            NrkSdk.SetCollectionObjectNameArg("Reference Frame", _sFrameCollection, _sFrameName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();

            if (bExcuteStatus)
            {
                if (NrkSdk.GetTransformArg("Resultant Transform", ref _TransformMatrix))
                {
                    // Setup the matrix for use with SDK method
                    VariantWrapper matrixobj = new VariantWrapper(_TransformMatrix);
                    Object objMatrix = matrixobj;

                    // AddFunctTreeItem(MP_CONSTRUCT_FRAME,_T("Construct Frame"),IDI_MP_DEFAULT,TRUE,ret2,1);
                    // AddFunctArg(MP_CONSTRUCT_FRAME,MP_ARG_COL_OBJECT_NAME,_T("New Frame Name"), FALSE);
                    // AddFunctArg(MP_CONSTRUCT_FRAME,MP_ARG_TRANSFORM,_T("Transform in Working Coordinates"));

                    //NrkSdk.SetStep("Construct Frame");
                    //NrkSdk.SetCollectionObjectNameArg("New Frame Name", "", "Test Frame");
                    //NrkSdk.SetTransformArg("Transform in Working Coordinates", ref objMatrix);
                    //bExcuteStatus = NrkSdk.ExecuteStep();
                }
            }

            //    double T[4][4];
            ////SDKHelper helper(NrkSdk);
            //helper.GetTransformArgHelper("Transform", T);
            return bExcuteStatus;
        }

        public bool SetInstrumentTransform(string _col, int InsID, double[,] _Trans)
        {
            NrkSdk.SetStep("Set Instrument Transform");
            NrkSdk.SetColInstIdArg("Instrument to Move", _col, InsID/* Conversion error: Set to default value for this argument */);
            object vMatrixobj = new System.Runtime.InteropServices.VariantWrapper(_Trans);
            NrkSdk.SetTransformArg("Destination Transform", vMatrixobj);
            NrkSdk.SetCollectionObjectNameArg("Reference Frame", _col, "World");
            NrkSdk.SetIntegerArg("Number of Steps", 1);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        //    public bool GetInstrumentWeatherSetting()
        //{
        //    NrkSdk.SetStep("Get Instrument Weather Setting");
        //    NrkSdk.SetColInstIdArg("Instrument's ID", "", );
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Temperature (F)", &value);

        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Pressure (mmHg)", &value);

        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Humidity (%Rel)", &value);

        //    BOOL bValue;
        //    NrkSdk.GetBoolArg("Was Set Automatically? (using Inst or external sensor", &bValue);
        //    return bExcuteStatus;
        //}

        //public bool SetInstrumentWeatherSetting()
        //{
        //    NrkSdk.SetStep("Set Instrument Weather Setting");
        //    NrkSdk.SetColInstIdArg("Instrument's ID", "", );
        //    NrkSdk.SetDoubleArg("Temperature (F)", 0.000000);
        //    NrkSdk.SetDoubleArg("Pressure (mmHg)", 0.000000);
        //    NrkSdk.SetDoubleArg("Humidity (%Rel)", 0.000000);
        //    NrkSdk.SetBoolArg("Set Automatically? (Ignore above values)", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool ComputeCTEScaleFactor()
        //{
        //    NrkSdk.SetStep("Compute CTE Scale Factor");
        //    NrkSdk.SetDoubleArg("Material CTE (1/Deg F)", 0.000000);
        //    NrkSdk.SetDoubleArg("Initial Temperature (F)", 0.000000);
        //    NrkSdk.SetDoubleArg("Final Temperature (F)", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Scale Factor", &value);

        //    return bExcuteStatus;
        //}

        public bool SetAbsoluteInstrumentScaleFactorCAUTION(string _Col, int _InsID, double _Scale)
        {
            NrkSdk.SetStep("Set (absolute) Instrument Scale Factor (CAUTION!)");
            NrkSdk.SetColInstIdArg("Instrument's ID", _Col, _InsID/* Conversion error: Set to default value for this argument */);
            NrkSdk.SetDoubleArg("Scale Factor", _Scale);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        //public bool SetMultiplyInstrumentScaleFactorCAUTION()
        //{
        //    NrkSdk.SetStep("Set (multiply) Instrument Scale Factor (CAUTION!)");
        //    NrkSdk.SetColInstIdArg("Instrument's ID", "", );
        //    NrkSdk.SetDoubleArg("Scale Factor", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool GetInstrumentScaleFactor()
        //{
        //    NrkSdk.SetStep("Get Instrument Scale Factor");
        //    NrkSdk.SetColInstIdArg("Instrument's ID", "", );
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Scale Factor", &value);

        //    return bExcuteStatus;
        //}

        //public bool TransformInstrumentFrameToFrame()
        //{
        //    NrkSdk.SetStep("Transform Instrument - Frame To Frame");
        //    NrkSdk.SetColInstIdArg("Instrument to move", "", );
        //    NrkSdk.SetCollectionObjectNameArg("Initial Frame Name", "", "");
        //    NrkSdk.SetCollectionObjectNameArg("Destination Frame Name", "", "");
        //    NrkSdk.SetIntegerArg("Number of Steps", 0);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool TransformInstrumentByDelta()
        //{
        //    NrkSdk.SetStep("Transform Instrument by Delta");
        //    NrkSdk.SetColInstIdArg("Instrument to Transform", "", );
        //    double T[4][4];
        //	double scale;
        //T[0][0] = 1.000000; 	T[0][1] = -0.000000; 	T[0][2] = 0.000000; 	T[0][3] = 0.000000; 
        //	T[1][0] = 0.000000; 	T[1][1] = 1.000000; 	T[1][2] = -0.000000; 	T[1][3] = 0.000000; 
        //	T[2][0] = 0.000000; 	T[2][1] = 0.000000; 	T[2][2] = 1.000000; 	T[2][3] = 0.000000; 
        //	T[3][0] = 0.000000; 	T[3][1] = 0.000000; 	T[3][2] = 0.000000; 	T[3][3] = 1.000000; 
        //	scale = 1.000000;
        //	SDKHelper helper(NrkSdk);
        //helper.SetWorldTransformArgHelper("Delta Transform", T, scale);
        //	NrkSdk.SetBoolArg("Apply Scale from Transform to Instrument", FALSE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();
        //return bExcuteStatus;
        //    }


        //    public bool TransformMultipleInstrumentsByDelta()
        //{
        //    NrkSdk.SetStep("Transform Multiple Instruments By Delta");
        //    CStringArray instObjList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetColInstIdRefListArgHelper("Instruments to Move", instObjList);
        //    double T[4][4];
        //	double scale;
        //T[0][0] = 1.000000; 	T[0][1] = -0.000000; 	T[0][2] = 0.000000; 	T[0][3] = 0.000000; 
        //	T[1][0] = 0.000000; 	T[1][1] = 1.000000; 	T[1][2] = -0.000000; 	T[1][3] = 0.000000; 
        //	T[2][0] = 0.000000; 	T[2][1] = 0.000000; 	T[2][2] = 1.000000; 	T[2][3] = 0.000000; 
        //	T[3][0] = 0.000000; 	T[3][1] = 0.000000; 	T[3][2] = 0.000000; 	T[3][3] = 1.000000; 
        //	scale = 1.000000;
        //	SDKHelper helper(NrkSdk);
        //helper.SetWorldTransformArgHelper("Delta Transform", T, scale);
        //	NrkSdk.SetBoolArg("Apply Scale from Transform to Instrument", FALSE);
        //bool bExcuteStatus = NrkSdk.ExecuteStep();
        //return bExcuteStatus;
        //    } 

        //    public bool InstrumentOperationalCheck()
        //{
        //    NrkSdk.SetStep("Instrument Operational Check");
        //    NrkSdk.SetColInstIdArg("Instrument to Check", "", );
        //    NrkSdk.SetStringArg("Check Type", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool GetNumberOfObservationsOnTarget()
        //{
        //    NrkSdk.SetStep("Get Number of Observations on Target");
        //    NrkSdk.SetPointNameArg("Point Name", "", "", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    long value;
        //    NrkSdk.GetIntegerArg("Number of Shots", &value);
        //    return bExcuteStatus;
        //}


        //public bool GetInstrumentsWithObservationsOnTarget()
        //{
        //    NrkSdk.SetStep("Get Instruments with Observations on Target");
        //    NrkSdk.SetPointNameArg("Point Name", "", "", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    CStringArray instIdList;
        //    SDKHelper helper(NrkSdk);
        //    helper.GetColInstIdRefListArgHelper("Resultant Collection Instrument Reference List", instIdList);
        //    return bExcuteStatus;
        //}

        //public bool SetObservationStatus()
        //{
        //    NrkSdk.SetStep("Set Observation Status");
        //    NrkSdk.SetPointNameArg("Point Name", "", "", "");
        //    NrkSdk.SetIntegerArg("Observation Index", 0);
        //    NrkSdk.SetBoolArg("Active?", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool GetObservationInfo()
        //{
        //    NrkSdk.SetStep("Get Observation Info");
        //    NrkSdk.SetPointNameArg("Point Name", "", "", "");
        //    NrkSdk.SetIntegerArg("Observation Index", 0);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    BSTR sCol = NULL;
        //    long instId;
        //    NrkSdk.GetColInstIdArg("Resulting Instrument", &sCol, &instId);
        //    CString colName = sCol;
        //::SysFreeString(sCol);

        //    DOUBLE xVal;
        //    DOUBLE yVal;
        //    DOUBLE zVal;
        //    NrkSdk.GetVectorArg("Resultant Vector", &xVal, &yVal, &zVal);

        //    BOOL bValue;
        //    NrkSdk.GetBoolArg("Active?", &bValue);
        //    return bExcuteStatus;
        //}

        //public bool FabricateObservations()
        //{
        //    NrkSdk.SetStep("Fabricate Observations");
        //    NrkSdk.SetColInstIdArg("Instrument to shoot", "", );
        //    NrkSdk.SetCollectionObjectNameArg("Group name to shoot", "", "");
        //    NrkSdk.SetBoolArg("Introduce instrument error?", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool SetInstrumentMeasurementModeProfile()
        //{
        //    NrkSdk.SetStep("Set Instrument Measurement Mode/Profile");
        //    NrkSdk.SetColInstIdArg("Instrument to set", "", );
        //    NrkSdk.SetStringArg("Mode/Profile", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool SetInstrumentGroupAndTarget()
        //{
        //    NrkSdk.SetStep("Set Instrument Group and Target");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    NrkSdk.SetPointNameArg("Point Name", "", "", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool SetInstrumentTargeting()
        //{
        //    NrkSdk.SetStep("Set Instrument Targeting");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    NrkSdk.SetStringArg("Targeting Name", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool GetInstrumentTargetStatus()
        //{
        //    NrkSdk.SetStep("Get Instrument Target Status");
        //    NrkSdk.SetColInstIdArg("Instrument's ID", "", );
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    BOOL bValue;
        //    NrkSdk.GetBoolArg("Is Locked?", &bValue);

        //    BSTR sValue = NULL;
        //    NrkSdk.GetStringArg("Name", &sValue);
        //    CString name = sValue;
        //::SysFreeString(sValue);
        //    long value;
        //    NrkSdk.GetIntegerArg("Number of Faces", &value);

        //    long value;
        //    NrkSdk.GetIntegerArg("Locked Face", &value);
        //    return bExcuteStatus;
        //}

        //public bool ScanWithinPerimeter()
        //{
        //    NrkSdk.SetStep("Scan within perimeter");
        //    NrkSdk.SetColInstIdArg("Instrument to scan", "", );
        //    NrkSdk.SetPerimeterNameArg("Scan perimeter name", "");
        //    NrkSdk.SetStringArg("Parameter set name", "");
        //    NrkSdk.SetCollectionObjectNameArg("Group name", "", "");
        //    NrkSdk.SetBoolArg("Wait for Completion", TRUE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool EdgeScanMeasurement()
        //{
        //    NrkSdk.SetStep("Edge Scan Measurement");
        //    NrkSdk.SetColInstIdArg("Instrument to scan", "", );
        //    NrkSdk.SetPointNameArg("Point near edge", "", "", "");
        //    NrkSdk.SetPointNameArg("Point in edge search direction", "", "", "");
        //    NrkSdk.SetStringArg("Parameter set name", "");
        //    NrkSdk.SetCollectionObjectNameArg("Group Name", "", "");
        //    NrkSdk.SetStringArg("Target Name", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool TrackTapeMeasurement()
        //{
        //    NrkSdk.SetStep("Track Tape Measurement");
        //    NrkSdk.SetColInstIdArg("Instrument to scan", "", );
        //    NrkSdk.SetPointNameArg("Point on Tape", "", "", "");
        //    NrkSdk.SetPointNameArg("Point on Part", "", "", "");
        //    NrkSdk.SetPointNameArg("Point for Direction", "", "", "");
        //    NrkSdk.SetPointNameArg("Point for Termination", "", "", "");
        //    NrkSdk.SetStringArg("Parameter set name", "");
        //    NrkSdk.SetCollectionObjectNameArg("Group Name", "", "");
        //    NrkSdk.SetStringArg("Initial Target Name", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        public bool AutoMeasurePoints(string _InsCollection, int _InsID, string _RefGroupCol, string _RefGroupName, string _ActGroupCol, string _ActGroupName,
    bool _bShowDialog, bool _bWaitForCompletion, bool _bAutoStart)
        {
            NrkSdk.SetStep("Auto Measure Points");
            NrkSdk.SetColInstIdArg("Instrument ID", _InsCollection, _InsID);
            NrkSdk.SetCollectionObjectNameArg("Reference Group Name", _RefGroupCol, _RefGroupName);
            NrkSdk.SetCollectionObjectNameArg("Actuals Group Name (to be measured)", _ActGroupCol, _ActGroupName);
            NrkSdk.SetBoolArg("Show complete dialog?", _bShowDialog);
            NrkSdk.SetBoolArg("Wait for Completion?", _bWaitForCompletion);
            NrkSdk.SetBoolArg("Auto Start?", _bAutoStart);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //public bool AutoMeasureVectors()
        //{
        //    NrkSdk.SetStep("Auto-Measure Vectors");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    NrkSdk.SetCollectionObjectNameArg("Vector Group Name", "", "");
        //    NrkSdk.SetCollectionObjectNameArg("Actuals Group Name (to be measured)", "", "");
        //    NrkSdk.SetBoolArg("Project Point to Vector", FALSE);
        //    NrkSdk.SetDoubleArg("Angle Tolerance", 0.000000);
        //    NrkSdk.SetDoubleArg("High Tolerance", 0.000000);
        //    NrkSdk.SetDoubleArg("Low Tolerance", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        public bool AutoMeasureSpecifiedGeometry(string _InsCollection, int _InsID, string _ObjCol, string _ObjName, string _MeasMode, bool _bWaitForComplete)
        {
            NrkSdk.SetStep("Auto-Measure Specified Geometry");
            NrkSdk.SetColInstIdArg("Instrument ID", _InsCollection, _InsID);
            NrkSdk.SetCollectionObjectNameArg("Object", _ObjCol, _ObjName);
            NrkSdk.SetStringArg("Mode/Profile", _MeasMode);
            NrkSdk.SetBoolArg("Wait for Complete", _bWaitForComplete);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //public bool AutoCorrespondClosestPoint()
        //{
        //    NrkSdk.SetStep("Auto-Correspond Closest Point");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    NrkSdk.SetCollectionObjectNameArg("Reference Group Name", "", "");
        //    NrkSdk.SetCollectionObjectNameArg("Actuals Group Name (to be measured)", "", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool AutoCorrespondWithProximityTrigger()
        //{
        //    NrkSdk.SetStep("Auto-Correspond with Proximity Trigger");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    NrkSdk.SetCollectionObjectNameArg("Nominal Point Group or Vector Group", "", "");
        //    NrkSdk.SetCollectionObjectNameArg("Results Point Group for measurements", "", "");
        //    NrkSdk.SetDoubleArg("Point distance threshold", 0.500000);
        //    NrkSdk.SetDoubleArg("Vector axis threshold", 0.250000);
        //    NrkSdk.SetBoolArg("Project results to nominal vector", FALSE);
        //    NrkSdk.SetDoubleArg("Warbler ramp start zone distance", 12.000000);
        //    NrkSdk.SetBoolArg("Show Watch window on startup", FALSE);
        //    NrkSdk.SetVectorGroupNameArg("Vector Group to make while Measuring (blank means ignore)", "");
        //    NrkSdk.SetBoolArg("Make unmeasured group when done", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool ConstructMirrorFromPlane()
        //{
        //    NrkSdk.SetStep("Construct Mirror from Plane");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    NrkSdk.SetStringArg("Mirror Name", "");
        //    NrkSdk.SetCollectionObjectNameArg("Plane", "", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool DriftCheck()
        //{
        //    NrkSdk.SetStep("Drift Check");
        //    NrkSdk.SetColInstIdArg("Instrument to check", "", );
        //    NrkSdk.SetCollectionObjectNameArg("Reference Group Name", "", "");
        //    NrkSdk.SetCollectionObjectNameArg("Actuals Group Name (to be measured)", "", "");
        //    NrkSdk.SetDoubleArg("Tolerance", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool MeasureNominalFeature()
        //{
        //    NrkSdk.SetStep("Measure Nominal Feature");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    NrkSdk.SetCollectionObjectNameArg("Feature Name", "", "");
        //    NrkSdk.SetPointNameArg("Resulting Point Name", "", "", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool GuideObjectsIn6DBasedOnPointMeasurements()
        //{
        //    NrkSdk.SetStep("Guide Objects in 6D based on Point Measurements");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    NrkSdk.SetCollectionObjectNameArg("Destination Group (goal)", "", "");
        //    NrkSdk.SetCollectionObjectNameArg("Moving Reference Group (attached to objects)", "", "");
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Objects to Move", objNameList);
        //    NrkSdk.SetCollectionObjectNameArg("Initially surveyed Group (First Position Measurements - Optional)", "", "");
        //    NrkSdk.NOT_SUPPORTED("Positional Tolerance - Optional");
        //    NrkSdk.NOT_SUPPORTED("Rotational Tolerance - Optional");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool MoveObjectsIn6DUsingInstrumentUpdates()
        //{
        //    NrkSdk.SetStep("Move Objects in 6D using Instrument Updates");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Objects to Move", objNameList);
        //    NrkSdk.SetStringArg("Measurement Mode", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool AlignTwoTargetsWithAxisWCFX()
        //{
        //    NrkSdk.SetStep("Align Two Targets with Axis (WCF - X)");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    NrkSdk.SetPointNameArg("First Point On Axis", "", "", "");
        //    NrkSdk.SetPointNameArg("Second Point On Axis", "", "", "");
        //    NrkSdk.SetCollectionObjectNameArg("Initial Measured Group", "", "");
        //    NrkSdk.NOT_SUPPORTED("Rotational Tolerance - Optional");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        public bool GetInstrumentInterfaceResponseTimeout(string _sInsCol, int _iInsId, ref double _dInsTimeOutValue)
        {
            NrkSdk.SetStep("Get Instrument Interface Response Timeout");
            NrkSdk.SetColInstIdArg("Instrument ID", _sInsCol, _iInsId);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            NrkSdk.GetDoubleArg("Resulting Timeout Value (secs)", _dInsTimeOutValue);
            return bExcuteStatus;
        }

        public bool SetInstrumentInterfaceResponseTimeout(string _sInsCol, int _iInsId, double _dInsTimeOutValue)
        {
            NrkSdk.SetStep("Set Instrument Interface Response Timeout");
            NrkSdk.SetColInstIdArg("Instrument ID", _sInsCol, _iInsId);
            NrkSdk.SetDoubleArg("Timeout (secs)", _dInsTimeOutValue);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool JumpInstrumentToNewLocation(string _sInsCol, int _iInsId, bool _bHidePreIns)
        {
            NrkSdk.SetStep("Jump Instrument To New Location");
            NrkSdk.SetColInstIdArg("Live Instrument ID", _sInsCol, _iInsId);
            NrkSdk.SetBoolArg("Hide the Previous Instrument?", _bHidePreIns);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //public bool QuickAlign()
        //{
        //    NrkSdk.SetStep("Quick Align");
        //    CStringArray instObjList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetColInstIdRefListArgHelper("Instrument IDs", instObjList);
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Objects", objNameList);
        //    CStringArray ptNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetPointNameRefListArgHelper("Nominal Points (optional)", ptNameList);
        //    CStringArray stringList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetStringRefListArgHelper("Nominal Point of View Names (optional)", stringList);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool StartGDTInspectionDesign()
        //{
        //    NrkSdk.SetStep("Start GD&T Inspection Design");
        //    NrkSdk.SetCollectionNameArg("Collection Name", "");
        //    NrkSdk.SetStringArg("Filter (ALL/CHECKS/DATUMS)", "ALL");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool StartGDTInspectionRehearse()
        //{
        //    NrkSdk.SetStep("Start GD&T Inspection Rehearse");
        //    NrkSdk.SetCollectionNameArg("Collection Name", "");
        //    NrkSdk.SetStringArg("Filter (ALL/CHECKS/DATUMS)", "ALL");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool StartGDTInspection()
        //{
        //    NrkSdk.SetStep("Start GD&T Inspection");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    NrkSdk.SetCollectionNameArg("Collection Name", "");
        //    NrkSdk.SetStringArg("Filter (ALL/CHECKS/DATUMS)", "ALL");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool AssociateObjectsWithInstrument()
        //{
        //    NrkSdk.SetStep("Associate Objects with Instrument");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Objects", objNameList);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool DisassociateObjectsFromInstrument()
        //{
        //    NrkSdk.SetStep("Disassociate Objects from Instrument");
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Objects", objNameList);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool MakeCollectionObjectNameRefListFromObjectsAssociatedWithInstruments()
        //{
        //    NrkSdk.SetStep("Make Collection Object Name Ref List from Objects associated with Instruments");
        //    CStringArray instObjList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetColInstIdRefListArgHelper("Instrument IDs", instObjList);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.GetCollectionObjectNameRefListArgHelper("Resultant Collection Object Name List", objNameList);

        //    return bExcuteStatus;
        //}


        public bool SetUserInterfaceProfile(string _sProfileName)
        {
            NrkSdk.SetStep("Set User Interface Profile");
            NrkSdk.SetStringArg("Profile Name", _sProfileName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //public bool SetMPStepMode()
        //{
        //    NrkSdk.SetStep("Set MP Step Mode");
        //    NrkSdk.NOT_SUPPORTED("MP Step Mode");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool DelayForSpecifiedTime()
        //{
        //    NrkSdk.SetStep("Delay for specified time");
        //    NrkSdk.SetDoubleArg("Time to delay", 0.000000);
        //    NrkSdk.NOT_SUPPORTED("Time units");
        //    NrkSdk.SetBoolArg("Show progress dialog?", TRUE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool GetTickCount()
        //{
        //    NrkSdk.SetStep("Get Tick Count");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Tick Count (secs)", &value);
        //    return bExcuteStatus;
        //}

        //public bool SpeakToUser()
        //{
        //    NrkSdk.SetStep("Speak To User");
        //    NrkSdk.SetStringArg("String to speak", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        public bool GetActiveUnits(ref string _LengthUnit, ref string _AngularUnit, ref string _TemperatureUnit)
        {

            NrkSdk.SetStep("Get Active Units");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            //BSTR sValue = NULL;
            NrkSdk.GetStringArg("Length", _LengthUnit);
            //    CString name = sValue;
            //::SysFreeString(sValue);

            //BSTR sValue = NULL;
            NrkSdk.GetStringArg("Angular", _AngularUnit);
            //    CString name = sValue;
            //::SysFreeString(sValue);

            //BSTR sValue = NULL;
            NrkSdk.GetStringArg("Temperature", _TemperatureUnit);
            //    CString name = sValue;
            //::SysFreeString(sValue);
            return bExcuteStatus;
        }

        public bool SetActiveUnits(string _LengthUnit, string _AngularUnit, string _TemperatureUnit)
        {
            NrkSdk.SetStep("Set Active Units");
            NrkSdk.SetStringArg("Length", _LengthUnit);
            NrkSdk.SetStringArg("Angular", _AngularUnit);
            NrkSdk.SetStringArg("Temperature", _TemperatureUnit);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool SetWorkingFrame(string _FrameCol, string _FrameName)
        {
            NrkSdk.SetStep("Set Working Frame");
            NrkSdk.SetCollectionObjectNameArg("New Working Frame Name", _FrameCol, _FrameName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }


        public bool GetPointCoordinate(string _pntCol, string _pntGroup, string _pntName, ref double _x, ref double _y, ref double _z)
        {
            NrkSdk.SetStep("Get Point Coordinate");
            NrkSdk.SetPointNameArg("Point Name", _pntCol, _pntGroup, _pntName);

            bool bExcuteStatus = NrkSdk.ExecuteStep();
            if (bExcuteStatus)
            {
                NrkSdk.GetVectorArg("Vector Representation", ref _x, ref _y, ref _z);
            }

            return bExcuteStatus;
        }

        public bool GetPointCoordinateCylindrical(string _sPntCol, string _sPntGrp, string _sPntName,
            ref double _dRadius, ref double _dTheta, ref double _dZ)
        {
            NrkSdk.SetStep("Get Point Coordinate (Cylindrical)");
            NrkSdk.SetPointNameArg("Point Name", _sPntCol, _sPntGrp, _sPntName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            if (bExcuteStatus)
            {
                NrkSdk.GetDoubleArg("Radius Value", ref _dRadius);
                NrkSdk.GetDoubleArg("Theta Value", ref _dTheta);
                NrkSdk.GetDoubleArg("Z Value", ref _dZ);

            }
            return bExcuteStatus;
        }

        public bool GetPointCoordinatePolar(string _sPntCol, string _sPntGrp, string _sPntName,
            ref double _dRadius, ref double _dTheta, ref double _dPhi)
        {
            NrkSdk.SetStep("Get Point Coordinate (Polar)");
            NrkSdk.SetPointNameArg("Point Name", _sPntCol, _sPntGrp, _sPntName);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            if (bExcuteStatus)
            {
                NrkSdk.GetDoubleArg("Radius Value", ref _dRadius);
                NrkSdk.GetDoubleArg("Theta Value", ref _dTheta);
                NrkSdk.GetDoubleArg("Phi Value", ref _dPhi);
            }
            return bExcuteStatus;
        }


        public bool GetWorkingFrameProperties(ref string _sFrameCol, ref string _sFrameName)
        {
            NrkSdk.SetStep("Get Working Frame Properties");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            if (bExcuteStatus)
            {
                NrkSdk.GetStringArg("Collection Name", ref _sFrameCol);
                NrkSdk.GetStringArg("Frame Name", ref _sFrameName);
            }
            return bExcuteStatus;
        }

        public bool SetWorkingColor(byte _r, byte _g, byte _b)
        {
            NrkSdk.SetStep("Set Working Color");
            NrkSdk.SetColorArg("New Working Color Name", _r, _g, _b);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //public bool SetObjectColor()
        //{
        //    NrkSdk.SetStep("Set Object(s) Color");
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Objects to change", objNameList);
        //    NrkSdk.SetColorArg("New Working Color Name", 255, 0, 0);
        //    NrkSdk.SetBoolArg("Auto Increment", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        public bool SetWorkingColorAutoIncrement(bool _bAutoIncrement)
        {
            NrkSdk.SetStep("Set Working Color Auto Increment");
            NrkSdk.SetBoolArg("Auto Increment", _bAutoIncrement);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //public bool SetObjectTranslucency()
        //{
        //    NrkSdk.SetStep("Set Object(s) Translucency");
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Objects to change", objNameList);
        //    NrkSdk.NOT_SUPPORTED("Rendering Type");
        //    NrkSdk.SetDoubleArg("Opacity Value", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool MoveRobotMachineToFrame()
        //{
        //    NrkSdk.SetStep("Move Robot/Machine to Frame");
        //    NrkSdk.SetColMachineIdArg("Machine ID", "", );
        //    NrkSdk.SetCollectionObjectNameArg("Destination Frame", "", "");
        //    NrkSdk.SetBoolArg("Use SA Kinematics", FALSE);
        //    NrkSdk.SetBoolArg("Acknowledge Arrival", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    double T[4][4];
        //SDKHelper helper(NrkSdk);
        //helper.GetTransformArgHelper("Actual Transform In Working (result)", T);

        //    return bExcuteStatus;
        //}

        //public bool MoveRobotMachineThroughPath()
        //{
        //    NrkSdk.SetStep("Move Robot/Machine through Path");
        //    NrkSdk.SetColMachineIdArg("Machine ID", "", );
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Path Frames", objNameList);
        //    NrkSdk.SetBoolArg("Use SA Kinematics", TRUE);
        //    NrkSdk.SetBoolArg("Linear Segments", FALSE);
        //    NrkSdk.SetBoolArg("Acknowledge Arrival", TRUE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool MoveRobotMachineToNamedDestination()
        //{
        //    NrkSdk.SetStep("Move Robot/Machine to Named Destination");
        //    NrkSdk.SetColMachineIdArg("Machine ID", "", );
        //    NrkSdk.SetStringArg("Destination Name", "");
        //    NrkSdk.SetBoolArg("Acknowledge Arrival", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    double T[4][4];
        //SDKHelper helper(NrkSdk);
        //helper.GetTransformArgHelper("Actual Transform In Working (result)", T);
        //    return bExcuteStatus;
        //}

        //public bool SetRobotMachineParameter()
        //{
        //    NrkSdk.SetStep("Set Robot/Machine Parameter");
        //    NrkSdk.SetColMachineIdArg("Machine ID", "", );
        //    NrkSdk.SetStringArg("Parameter Name", "");
        //    NrkSdk.SetDoubleArg("Parameter Value", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool GetRobotMachineParameter()
        //{
        //    NrkSdk.SetStep("Get Robot/Machine Parameter");
        //    NrkSdk.SetColInstIdArg("Machine ID", "", );
        //    NrkSdk.SetStringArg("Parameter Name", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Parameter Value", &value);
        //    return bExcuteStatus;
        //}

        //public bool StartRobotMachineInterface()
        //{
        //    NrkSdk.SetStep("Start Robot/Machine Interface");
        //    NrkSdk.SetColInstIdArg("Machine ID", "", );
        //    NrkSdk.SetIntegerArg("Interface Type", 0);
        //    NrkSdk.SetBoolArg("Run in Simulation", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool StopRobotMachineInterface()
        //{
        //    NrkSdk.SetStep("Stop Robot/Machine Interface");
        //    NrkSdk.SetColInstIdArg("Machine ID", "", );
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool ComputeRobotMachineAdjustedGoalFrame()
        //{
        //    NrkSdk.SetStep("Compute Robot/Machine Adjusted Goal Frame");
        //    NrkSdk.SetCollectionObjectNameArg("Original Goal Frame", "", "");
        //    NrkSdk.SetCollectionObjectNameArg("Last Adjusted Goal Frame", "", "");
        //    NrkSdk.SetCollectionObjectNameArg("Actual Measured Frame", "", "");
        //    NrkSdk.SetCollectionObjectNameArg("Modified Goal Frame", "", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    double T[4][4];
        //SDKHelper helper(NrkSdk);
        //helper.GetTransformArgHelper("Transform Value", T);

        //    return bExcuteStatus;
        //}

        //public bool MoveRobotMachineToJointPose6DOF()
        //{
        //    NrkSdk.SetStep("Move Robot/Machine to Joint Pose (6DOF)");
        //    NrkSdk.SetColMachineIdArg("Machine ID", "", );
        //    NrkSdk.SetDoubleArg("Joint 1", 0.000000);
        //    NrkSdk.SetDoubleArg("Joint 2", 0.000000);
        //    NrkSdk.SetDoubleArg("Joint 3", 0.000000);
        //    NrkSdk.SetDoubleArg("Joint 4", 0.000000);
        //    NrkSdk.SetDoubleArg("Joint 5", 0.000000);
        //    NrkSdk.SetDoubleArg("Joint 6", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool SimulateRobotMachinePathOutputCSVFile()
        //{
        //    NrkSdk.SetStep("Simulate Robot/Machine Path, Output CSV File");
        //    NrkSdk.SetColMachineIdArg("Machine ID", "", );
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Path Frames", objNameList);
        //    NrkSdk.SetFilePathArg("Output CSV File", "", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool CreateRobotCalibration()
        //{
        //    NrkSdk.SetStep("Create Robot Calibration");
        //    NrkSdk.SetColMachineIdArg("Machine ID", "", );
        //    NrkSdk.SetStringArg("Calibration Name", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool DeleteRobotCalibration()
        //{
        //    NrkSdk.SetStep("Delete Robot Calibration");
        //    NrkSdk.SetColMachineIdArg("Machine ID", "", );
        //    NrkSdk.SetStringArg("Calibration Name", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool ImportPosesMatchToMeasurements()
        //{
        //    NrkSdk.SetStep("Import Poses Match to Measurements");
        //    NrkSdk.SetColMachineIdArg("Machine ID", "", );
        //    NrkSdk.SetStringArg("Calibration Name", "");
        //    CStringArray ptNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetPointNameRefListArgHelper("Point Names", ptNameList);
        //    NrkSdk.SetFilePathArg("FilePath for CSV Joint Set File", "", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool PerformRobotCalibration()
        //{
        //    NrkSdk.SetStep("Perform Robot Calibration");
        //    NrkSdk.SetColMachineIdArg("Machine ID", "", );
        //    NrkSdk.SetStringArg("Calibration Name", "");
        //    NrkSdk.NOT_SUPPORTED("Degrees of Freedom");
        //    NrkSdk.SetBoolArg("Show Interface", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("XYZ Max", &value);

        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("XYZ Average", &value);

        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("XYZ RMS", &value);

        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Orient Max", &value);

        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Orient Average", &value);

        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Orient RMS", &value);

        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Robustness", &value);
        //    return bExcuteStatus;
        //}

        //public bool StartStopRobotCalibrationTrapping()
        //{
        //    NrkSdk.SetStep("Start/Stop Robot Calibration Trapping");
        //    NrkSdk.SetColMachineIdArg("Machine ID", "", );
        //    NrkSdk.SetStringArg("Calibration Name", "");
        //    NrkSdk.SetColInstIdArg("Instrument ID", "", );
        //    NrkSdk.SetBoolArg("Start Trapping (FALSE = Stop)", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool SetActiveRobotCalibration()
        //{
        //    NrkSdk.SetStep("Set Active Robot Calibration");
        //    NrkSdk.SetColMachineIdArg("Machine ID", "", );
        //    NrkSdk.SetStringArg("Calibration Name", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool SendMPResultToExternalDevice()
        //{
        //    NrkSdk.SetStep("Send MP Result to External Device");
        //    NrkSdk.SetStringArg("IP Address or computer name", "");
        //    NrkSdk.SetIntegerArg("Socket Port", 0);
        //    NrkSdk.SetResultArg("Result");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep(); return bExcuteStatus;
        //}


        //public bool SendMPStepsStatusToExternalDevice()
        //{
        //    NrkSdk.SetStep("Send MP Step's Status to External Device");
        //    NrkSdk.SetStringArg("IP Address or computer name", "");
        //    NrkSdk.SetIntegerArg("Socket Port", 0);
        //    NrkSdk.NOT_SUPPORTED("Step ID");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        public bool DeleteObjects(ref object _objNameList)
        {
            NrkSdk.SetStep("Delete Objects");
            NrkSdk.SetCollectionObjectNameRefListArg("Object Names", _objNameList);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //public bool HighlightObjects()
        //{
        //    NrkSdk.SetStep("Highlight Objects");
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Object Names (Empty to clear all)", objNameList);
        //    NrkSdk.SetBoolArg("HighLight Objects?", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool HighlightPoint()
        //{
        //    NrkSdk.SetStep("Highlight Point");
        //    NrkSdk.SetPointNameArg("Point Name (Empty to clear all)", "", "", "");
        //    NrkSdk.SetBoolArg("Show Point?", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool MoveObjectsDragGraphically()
        //{
        //    NrkSdk.SetStep("Move Objects Drag Graphically");
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Objects", objNameList);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool ScaleObjects()
        //{
        //    NrkSdk.SetStep("Scale Objects");
        //    CStringArray objNameList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetCollectionObjectNameRefListArgHelper("Objects", objNameList);
        //    NrkSdk.SetDoubleArg("Scale Factor", 0.000000);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool MoveInstrumentsDragGraphically()
        //{
        //    NrkSdk.SetStep("Move Instruments Drag Graphically");
        //    CStringArray instObjList;
        //    SDKHelper helper(NrkSdk);
        //    helper.SetColInstIdRefListArgHelper("Instruments", instObjList);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool SetSpecialMPMode()
        //{
        //    NrkSdk.SetStep("Set Special MP Mode");
        //    NrkSdk.SetStringArg("Keyword", "");
        //    NrkSdk.SetBoolArg("Enable Special Mode?", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}


        //public bool IncrementPointName()
        //{
        //    NrkSdk.SetStep("Increment Point Name");
        //    NrkSdk.SetPointNameArg("'Base' Point Name", "", "", "");
        //    NrkSdk.SetIntegerArg("Increment", 0);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    BSTR sCol = NULL;
        //    BSTR sGrp = NULL;
        //    BSTR sTarg = NULL;
        //    NrkSdk.GetPointNameArg("Resultant Point Name", &sCol, &sGrp, &sTarg);
        //    CString collection = sCol;
        //    CString group = sGrp;
        //    CString target = sTarg;
        //::SysFreeString(sCol);
        //::SysFreeString(sGrp);
        //::SysFreeString(sTarg);

        //    return bExcuteStatus;
        //}

        public bool RefreshViews()
        {
            NrkSdk.SetStep("Refresh Views");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetLoggingState(bool _bLogStatusActive)
        {
            NrkSdk.SetStep("Set Logging State");
            NrkSdk.SetBoolArg("Active?", _bLogStatusActive);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool SetAutoEventCreation(bool _bAotuEventCreation)
        {
            NrkSdk.SetStep("Set Auto Event Creation");
            NrkSdk.SetBoolArg("Active?", _bAotuEventCreation);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        public bool WriteToLog(string _sLog)
        {
            NrkSdk.SetStep("Write to Log");
            NrkSdk.SetStringArg("Log Entry", _sLog);
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //public bool RemoveSpecifiedCharactersFromString()
        //{
        //    NrkSdk.SetStep("Remove Specified Characters From String");
        //    NrkSdk.SetStringArg("Characters to remove", "\:*?" <>|/ ");

        //    NrkSdk.SetStringArg("String to process", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();

        //    BSTR sValue = NULL;
        //    NrkSdk.GetStringArg("Resultant String", &sValue);
        //    CString name = sValue;
        //::SysFreeString(sValue);
        //    return bExcuteStatus;
        //}

        public bool CloseAllWatchWindows()
        {

            NrkSdk.SetStep("Close All Watch Windows");
            bool bExcuteStatus = NrkSdk.ExecuteStep();
            return bExcuteStatus;
        }

        //public bool StatusDialog()
        //{
        //    NrkSdk.SetStep("Status Dialog");
        //    NrkSdk.SetStringArg("Dialog Title", "");
        //    NrkSdk.SetStringArg("Text Message", "");
        //    NrkSdk.SetIntegerArg("Current Position", 0);
        //    NrkSdk.SetIntegerArg("Upper Limit", 0);
        //    NrkSdk.SetBoolArg("Suppress Time Remaining?", TRUE);
        //    NrkSdk.SetBoolArg("Close Dialog?", FALSE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool SetWorkingDirectory()
        //{
        //    NrkSdk.SetStep("Set Working Directory");
        //    NrkSdk.NOT_SUPPORTED("Working Directory");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool MakeDirectory()
        //{
        //    NrkSdk.SetStep("Make Directory");
        //    NrkSdk.NOT_SUPPORTED("Directory");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool DirectoryExistence()
        //{
        //    NrkSdk.SetStep("Directory Existence");
        //    NrkSdk.NOT_SUPPORTED("Directory");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    BOOL bValue;
        //    NrkSdk.GetBoolArg("Exists?", &bValue);
        //    return bExcuteStatus;
        //}

        //public bool DeleteDirectory()
        //{
        //    NrkSdk.SetStep("Delete Directory");
        //    NrkSdk.NOT_SUPPORTED("Directory");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool CopyDirectory()
        //{
        //    NrkSdk.SetStep("Copy Directory");
        //    NrkSdk.NOT_SUPPORTED("Source Directory");
        //    NrkSdk.NOT_SUPPORTED("Destination Directory");
        //    NrkSdk.SetBoolArg("Replace Existing?", TRUE);
        //    NrkSdk.SetBoolArg("Show Progress?", TRUE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool GenerateRandomNumber()
        //{
        //    NrkSdk.SetStep("Generate Random Number");
        //    NrkSdk.SetBoolArg("Gaussian distributed?", TRUE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool RandomNumber()
        //{
        //    DOUBLE value;
        //    NrkSdk.GetDoubleArg("Random Number", &value);
        //    NrkSdk.SetStep("Set View Idle Update Frequency");
        //    NrkSdk.SetIntegerArg("Idle Count", 0);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool SetAutomaticBackupState()
        //{
        //    NrkSdk.SetStep("Set Automatic Backup State");
        //    NrkSdk.SetBoolArg("Auto Job File Restore Points Active?", TRUE);
        //    NrkSdk.SetBoolArg("Auto Measurements Backup Active?", TRUE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool SetNotificationCancelOverride()
        //{
        //    NrkSdk.SetStep("Set Notification Cancel Override");
        //    NrkSdk.SetBoolArg("Prohibit Cancel?", TRUE);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool SetInteractionMode()
        //{
        //    NrkSdk.SetStep("Set Interaction Mode");
        //    // Available options: 
        //    // "Manual", "Automatic", "Silent", 
        //    NrkSdk.SetSAInteractionModeArg("SA Interaction Mode", "");
        //    // Available options: 
        //    // "Halt on Failure Only", "Halt on Failure or Partial Success", "Never Halt", 
        //    NrkSdk.SetMPInteractionModeArg("Measurement Plan Interaction Mode", "");
        //    // Available options: 
        //    // "Block Application Interaction", "Allow Application Interaction", 
        //    NrkSdk.SetMPDialogInteractionModeArg("Measurement Plan Dialog Interaction Mode", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool UDPSendString()
        //{
        //    NrkSdk.SetStep("UDP Send String");
        //    NrkSdk.SetStringArg("Destination Host", "");
        //    NrkSdk.SetIntegerArg("Destination Port", 0);
        //    NrkSdk.SetStringArg("String to Send", "");
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    return bExcuteStatus;
        //}

        //public bool UDPReceiveString()
        //{
        //    NrkSdk.SetStep("UDP Receive String");
        //    NrkSdk.SetIntegerArg("Local Port", 0);
        //    NrkSdk.SetIntegerArg("Timeout (secs), 0 for none", 0);
        //    bool bExcuteStatus = NrkSdk.ExecuteStep();
        //    BSTR sValue = NULL;
        //    NrkSdk.GetStringArg("Received String", &sValue);
        //    CString name = sValue;
        //::SysFreeString(sValue);

        //    BSTR sValue = NULL;
        //    NrkSdk.GetStringArg("Sender Host", &sValue);
        //    CString name = sValue;
        //::SysFreeString(sValue);

        //    long value;
        //    NrkSdk.GetIntegerArg("Sender Port", &value);
        //    return bExcuteStatus;
        //}




        //public bool AddNewInstrument(string Type, ref string sCol, ref int instId)
        //{

        //    NrkSdk.SetStep("Add New Instrument");

        //    //   REM Available options:
        //    //           REM "Faro Vantage", "Faro Tracker", "Faro Ion Tracker", "SMX Tracker 4000,4500", "Leica Tracker TP-LINK", 
        //    //REM "Leica emScon Tracker (LT500-800 Series)", "Leica emScon Absolute Tracker (AT901 Series)", "Leica emScon AT401", "Leica emScon AT402", "API Tracker II", 
        //    //REM "API Tracker III", "API OmniTrac", "API Tracker Device Interface", "API Radian", "API OmniTrac2", 
        //    //REM "API Laser Rail", "Boeing Laser Tracker", "Chesapeake 3000 Laser Tracker", "Metris Laser Radar MV200", "Nikon Metrology Metris Laser Radar MV300", 
        //    //REM "Metris Laser Radar (CLRICx)", "Metris CLR 100 Laser Radar", "Boeing TaLLS Scanner", "Leica TPS Total Station (2003,5000,5005)", "Leica TDA5005 Total Station (GeoCOM)", 
        //    //REM "Leica Total Station TC2000, TC2002", "Leica Nova MS50 Total Station", "Leica TDRA6000 Total Station", "Sokkia SETX Total Station", "Sokkia Net05X Total Station", 
        //    //REM "Sokkia Net05AX Total Station", "Sokkia Net-1 Total Station", "Sokkia Net-2 Total Station", "FARO Arm", "FARO Arm G04", 
        //    //REM "FARO Arm S08", "FARO Arm G08", "FARO Arm S12", "FARO Arm G12", "FARO Arm G04-05 (7dof)", 
        //    //REM "FARO Arm G08-05 (7dof)", "FARO Arm G12-05 (7dof)", "FARO Arm USB 4 ft.", "FARO Arm USB 6 ft.", "FARO Arm USB 8 ft. & Quantum", 
        //    //REM "FARO Arm USB 10 ft.", "FARO Arm USB 12 ft.", "FARO Arm USB 4 ft. (7 dof)", "FARO Arm USB 6 ft. (7 dof)", "FARO Arm USB 8 ft. & Quantum (7 dof)", 
        //    //REM "FARO Arm USB 10 ft. (7 dof)", "FARO Arm USB 12 ft. (7 dof)", "FARO Edge Arm 9 ft. (7 dof)", "CimCore Arm 1024", "CimCore Arm 1028", 
        //    //REM "CimCore Arm 1030", "CimCore Arm 2200", "CimCore Arm 2500", "CimCore Arm 6DOF: 3012i, 5012, 1.2m", "CimCore Arm 6DOF: 3018i, 5018, 1.8m", 
        //    //REM "CimCore Arm 6DOF: 3024i, 5024, 2.4m", "CimCore Arm 6DOF: 3028i, 5028, 2.8m", "CimCore Arm 6DOF: 3036i, 5036, 3.6m", "CimCore Arm 7DOF: 5012Sc, 3012, 1.2m", "CimCore Arm 7DOF: 5018Sc, 3018, 1.8m", 
        //    //REM "CimCore Arm 7DOF: 5030Sc, 3030, 3.0m", "CimCore Arm 7DOF: 5028Sc, 3028, 2.8m", "CimCore Arm 7DOF: 5024Sc, 3024, 2.4m", "CimCore Arm 7DOF: 5036Sc, 3036, 3.6m", "CimCore Arm 7DOF: 5112Sc, 1.2m", 
        //    //REM "CimCore Arm 7DOF: 5118Sc, 1.8m", "CimCore Arm 7DOF: 5130Sc, 3.0m", "CimCore Arm 7DOF: 5128Sc, 2.8m", "CimCore Arm 7DOF: 5124Sc, 2.4m", "CimCore Arm 7DOF: 5136Sc, 3.6m", 
        //    //REM "CimCore Arm 6DOF: 5112, 1.2m", "CimCore Arm 6DOF: 5118, 1.8m", "CimCore Arm 6DOF: 5130, 3.0m", "CimCore Arm 6DOF: 5128, 2.8m", "CimCore Arm 6DOF: 5124, 2.4m", 
        //    //REM "CimCore Arm 6DOF: 5136, 3.6m", "Romer Multi-Gage", "Romer Absolute 7x20SI/SE", "Romer Absolute 7x25SI/SE", "Romer Absolute 7x30SI/SE", 
        //    //REM "Romer Absolute 7x35SI/SE", "Romer Absolute 7x40SI/SE", "Romer Absolute 7x45SI/SE", "Romer Absolute 7315", "Romer Absolute 7x20", 
        //    //REM "Romer Absolute 7x25", "Romer Absolute 7x30", "Romer Absolute 7x35", "Romer Absolute 7x40", "Romer Absolute 7x45", 
        //    //REM "Metris MCA Arm", "Romer Sigma Arm 2022", "Sandia National Labs Arm", "Axxis 6-100 Arm (2.6m 6 dof)", "Axxis 7-100 Arm Scanner (2.6m 7 dof)", 
        //    //REM "Axxis 7-100 Arm Probe (2.6m 7 dof)", "Axxis 6-200 Arm (3.2m 6 dof)", "Leica/Wild Theodolites T2000,T2002,T3000", "Leica TPS Theodolite (1800)", "Leica TPS Theodolite (5100)", 
        //    //REM "Zeiss ETh 2 Theodolite", "Kern E2 Theodolite", "Cubic KIT Theodolite", "GSI V-STARS Photogrammetry System", "AICON ProCam 3D Probe", 
        //    //REM "Metris K-Series (K-Scan & SpaceProbe)", "METRONOR Portable Measurement System", "Creaform Handy Probe", "Metris Surveyor", "Metris iGPS Network", 
        //    //REM "Metris iGPS Transmitter Simulator", "Metris Surveyor v2", "Metron Scanner", "Minolta VIVID 700 Scanner", "Minolta VIVID 900 Scanner", 
        //    //REM "Nivel 20 Two Axis Level", "Thommen HM30 Weather Station", "On-Trak Laser Line System (OT-4040, OT-6000)", "Davis Perception II Weather Station", "ScAlert Temperature Probe", 
        //    //REM "Ultrasonic Thickness Gauge (CL400)", "Imported Measurements with Uncertainty", "Virtek Laser Projector", "LPT Laser Projector", "Assembly Guidance Laser Projector", 
        //    //REM "LAP CAD-Pro Laser Projector", "SA Open Instrument", "SA Open Auxiliary Instrument", "Faro Scanner Photon/LS/Focus 3D", "Surphaser Scanner", 
        //    //REM "Leica Geosystems ScanStation P20", "Digital Network Level", "Creaform HandyScan 3D", "NDI OptoTrak", "Vicon Tracker", 
        //    //REM "AICON MoveInspect", "AICON DPA", "Leica TM6100A Theodolite", "Leica T1200 Total Station", "Leica TS15 Total Station", 
        //    //REM "Leica TS30 Total Station", "Ubisense RTLS", 
        //    NrkSdk.SetInstTypeNameArg("Instrument Type", Type);
        //    bool bSendStatus = NrkSdk.ExecuteStep();
        //    if (bSendStatus)
        //    {
        //        NrkSdk.GetColInstIdArg("Instrument Added (result)", sCol, instId);
        //    }

        //    return bSendStatus;
        //}


    }
}
