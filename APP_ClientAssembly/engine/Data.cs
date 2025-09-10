using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avril.ClientAssembly
{
    public class Data
    {
        static private Avril.ClientAssembly.Data_Control data_Control;
        //static private Avril.ClientAssembly.Game_Instance gameInstance;
        static private ClientAssembly.GameInstance.Settings settings;
        //byffers
        static private Avril.ClientAssembly.Inputs.Input_Instance input_Instnace;
        static private Avril.ClientAssembly.Outputs.Output_Instance output_Instnace;
        //stack        
        static private List<Avril.ClientAssembly.Outputs.Output> stack_Client_OutputRecieves;
        //praises
        static private Avril.ClientAssembly.Praise_Files.User_I user_I;

        static private bool state_Buffer_Input_ToWrite;
        static private bool state_Buffer_Output_ToWrite;

        public Data()
        {
            data_Control = null;
            
            //gameInstance = new Avril.ClientAssembly.Game_Instance();
            //while (gameInstance == null) { /* Wait while is created */ }

            settings = new Avril.ClientAssembly.GameInstance.Settings();
            while (settings == null) { /* Wait while is created */ }

            input_Instnace = new Avril.ClientAssembly.Inputs.Input_Instance();
            while (input_Instnace == null) { /* Wait while is created */ }

            output_Instnace = new Avril.ClientAssembly.Outputs.Output_Instance();
            while (output_Instnace == null) { /* Wait while is created */ }

            stack_Client_OutputRecieves = new List<Avril.ClientAssembly.Outputs.Output>();
            while (stack_Client_OutputRecieves == null) { /* Wait while is created */ }

            user_I = new Avril.ClientAssembly.Praise_Files.User_I();
            while (user_I == null) { /* Wait while is created */ }

            state_Buffer_Input_ToWrite = true;
            state_Buffer_Output_ToWrite = false;

            System.Console.WriteLine("Avril.ClientAssembly: Data");
        }

        public void InitialiseControl()
        {
            data_Control = new Avril.ClientAssembly.Data_Control();
            while (data_Control == null) { /* Wait while is created */ }
        }

        public void Flip_InBufferToWrite()
        {
            state_Buffer_Input_ToWrite = !state_Buffer_Input_ToWrite;
        }
        public void Flip_OutBufferToWrite()
        {
            state_Buffer_Output_ToWrite = !state_Buffer_Output_ToWrite;
        }

        public Avril.ClientAssembly.Data_Control Get_Data_Control()
        {
            return data_Control;
        }

        //public Avril.ClientAssembly.Game_Instance GetGame_Instance()
        //{
       //     return gameInstance;
        //}

        public Avril.ClientAssembly.Inputs.Input_Instance GetInput_Instnace()
        {
            return input_Instnace;
        }
        public Avril.ClientAssembly.Outputs.Output_Instance GetOutput_Instnace()
        {
            return output_Instnace;
        }

        public bool GetState_Buffer_InputPraise_SideToWrite()
        {
            return state_Buffer_Input_ToWrite;
        }
        public bool GetState_Buffer_OutputPraise_SideToWrite()
        {
            return state_Buffer_Output_ToWrite;
        }

        public ClientAssembly.GameInstance.Settings GetSettings()
        {
            return settings;
        }

        public List<Avril.ClientAssembly.Outputs.Output> GetStack_OutputsRecieved()
        {
            return stack_Client_OutputRecieves;
        }

        public Avril.ClientAssembly.Praise_Files.User_I GetUserI()
        {
            return user_I;
        }
    }
}
