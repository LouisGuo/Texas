﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34014
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TexasWpfApplication.ServiceGame {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceGame.GameSoap")]
    public interface GameSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/NewGame", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool NewGame();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FinishGame", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool FinishGame();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetGames", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable GetGames(int recordID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetGameByGameID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetGameByGameID(int gameID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GameSoapChannel : TexasWpfApplication.ServiceGame.GameSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GameSoapClient : System.ServiceModel.ClientBase<TexasWpfApplication.ServiceGame.GameSoap>, TexasWpfApplication.ServiceGame.GameSoap {
        
        public GameSoapClient() {
        }
        
        public GameSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GameSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GameSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GameSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public bool NewGame() {
            return base.Channel.NewGame();
        }
        
        public bool FinishGame() {
            return base.Channel.FinishGame();
        }
        
        public System.Data.DataTable GetGames(int recordID) {
            return base.Channel.GetGames(recordID);
        }
        
        public System.Data.DataSet GetGameByGameID(int gameID) {
            return base.Channel.GetGameByGameID(gameID);
        }
    }
}
