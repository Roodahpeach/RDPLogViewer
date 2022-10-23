using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RDPLogViewer
{
    internal class RDPLogCore
    {
        #region Variable

        public enum enum_Example_Language
        {
            ComiECATDLL,
            CSV
        }

        public enum enum_Func_Result
        {
            Success,
            Failure,
            Failure_NullRawData,
            Fallure_InvalidParam
        }

        private static RDPLogCore instance;
        public static RDPLogCore Instance { get { return instance; } }

        string LogFilePath;

        ArrayList LogRawData;

        List<RDPLogProtocol_ECATDLL> Trimmed_ECALDLL;

        #endregion

        //enum으로 로그의 타입 정하기 / ECATDLL, CSV 일단 이거 두개 구현

        /// <summary>
        /// 일단 다 읽어와서 RawData로 집어 넣는다
        /// 읽고나서 Trim 과정을 거친 뒤 각 프로토콜에 맞게끔 정리해서 넣자.
        /// </summary>
        /// <param name="FilePath"> 로그 파일 이름 </param>
        void File_Open(string FilePath)
        {
            
        }  

        /// <summary>
        /// Trim한 데이터 바탕으로 새로 저장하는 거
        /// </summary>
        /// <param name="FilePath"></param>
        void File_Save(string FilePath)
        {

        }
        
        /// <summary>
        /// 로그 Raw_Data를 적어도 깔끔하게 보일 수 있도록 한줄씩 출력하게 정리해주는 함수
        /// </summary>
        /// <param name="Enum_LogProtocol">어떤 로그인지에 대한 Enum값</param>
        int Log_Trimming(int Enum_LogProtocol)
        {
            //시작시 에러처리조건
            if(LogRawData == null)
            {
                return (int)enum_Func_Result.Failure_NullRawData;
            }
            if (Enum_LogProtocol < (int)enum_Example_Language.ComiECATDLL)
            {
                return (int)enum_Func_Result.Fallure_InvalidParam;
            }

            /*
             Case 1

             [14:01:45:954] <021927291> <ENTER> ecmSxMot_MoveToStart (0x0, 2, 175300, 0xa59f1b4): 
            [14:01:45:954] <021927299> <ENTER> ecaoSetChanVal_I (0x0, 0, 2333, 0xa05e2b0): 
            [14:01:45:955] <021927290> <EXIT > ecdoPutOne(): Ret=1, Err=0

               <021927291>  Before Move: CP=169163, FP=169163, Mst=0, Flg=0x9037, DI=0x8


            Case 2
            [13:49:14:586] <009465086> <EXIT > ecmSxSt_WaitCompt(): Ret=1, Err=0
            [13:49:14:769] <009486117> <ENTER> ecmIxCfg_MapAxes (0x0, 0, 02, 0x31ef3a8, 0xa05e2a8): 
               <009486117> 
            [in] AxisList[] = {5, 6}
             
            case 3

            [14:00:11:705] <020251143> <ENTER> ecmSxSt_WaitCompt (0x0, 7, 0x929e5f4):    <020251143>  After Compt: CP=1840, FP=1792, Mst=0, Flg=0x1037, DI=0x8[14:00:12:190] <020251143> <EXIT > ecmSxSt_WaitCompt(): Ret=1, Err=0
             */

            if (Enum_LogProtocol == (int)enum_Example_Language.ComiECATDLL)
            {
                //그냥 \n만 되어있거나 하는 경우는 일단 추가하지 않음.

                // '[' 가 새로운 행의 기준임. 같은 줄에 [가 또 있으면 다음 문장으로 처리하자
                // '<' 가 한번 더 나오는 경우는 Time은 이전과 동일하게 넣고 새로운 클래스 생성해서 넣는거로 하자
                // < 다음에 데이터가 아예 없는 경우에는 다음줄에 데이터가 있을 수 있음. 이것에 대한 처리 내용을 넣자
            }



            return (int)enum_Func_Result.Success;
        }

        void Log_Translation(int Enum_LogProtocol)
        {

        }
        
    }


    internal class RDPLogProtocol_ECATDLL
    {
        enum enum_RDPLogProtocol_ECATDLL
        {
            Vacant
        }
        string Time;
        string FunctionIndex;
        string FunctionName;
        string EnterorExit;
        string Contents;
    }
}
