﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34014
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TexasWpfApplication.ServicePlayerChip {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicePlayerChip.PlayerChipSoap")]
    public interface PlayerChipSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/NewLoan", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool NewLoan(int loanchips1, int loanchips2, int loanchips3, int loanchips4, int loanchips5, int loanchips6, int loanchips7, int loanchips8);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/JudgeWinner", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool JudgeWinner(int gainchips1, int gainchips2, int gainchips3, int gainchips4, int gainchips5, int gainchips6, int gainchips7, int gainchips8);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetStartChipsForJudgeShow", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetStartChipsForJudgeShow();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetStartChipsByGameID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetStartChipsByGameID(int gameID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetLastGameResultForLive", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetLastGameResultForLive();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetGameResultByGameID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetGameResultByGameID(int gameID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetPlayerChipsByRecordID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetPlayerChipsByRecordID(int recordID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SetHeadPicture", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool SetHeadPicture(int playerID, string headPicture);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetPlayerChipsInPoolForLive", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetPlayerChipsInPoolForLive(string chipsBet);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetChipsInPoolForLive", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetChipsInPoolForLive(string chipsBet);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetChipsInPoolByGameID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetChipsInPoolByGameID(int gameID, string chipsBet);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetMaxBetChipsForLive", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int GetMaxBetChipsForLive();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetTurnsBetChipsForNextPlayer", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int GetTurnsBetChipsForNextPlayer(int playerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetTurnsLeftBetChipsForNextPlayer", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int GetTurnsLeftBetChipsForNextPlayer(int playerID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PlayerChipSoapChannel : TexasWpfApplication.ServicePlayerChip.PlayerChipSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PlayerChipSoapClient : System.ServiceModel.ClientBase<TexasWpfApplication.ServicePlayerChip.PlayerChipSoap>, TexasWpfApplication.ServicePlayerChip.PlayerChipSoap {
        
        public PlayerChipSoapClient() {
        }
        
        public PlayerChipSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PlayerChipSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PlayerChipSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PlayerChipSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public bool NewLoan(int loanchips1, int loanchips2, int loanchips3, int loanchips4, int loanchips5, int loanchips6, int loanchips7, int loanchips8) {
            return base.Channel.NewLoan(loanchips1, loanchips2, loanchips3, loanchips4, loanchips5, loanchips6, loanchips7, loanchips8);
        }
        
        public bool JudgeWinner(int gainchips1, int gainchips2, int gainchips3, int gainchips4, int gainchips5, int gainchips6, int gainchips7, int gainchips8) {
            return base.Channel.JudgeWinner(gainchips1, gainchips2, gainchips3, gainchips4, gainchips5, gainchips6, gainchips7, gainchips8);
        }
        
        public System.Data.DataSet GetStartChipsForJudgeShow() {
            return base.Channel.GetStartChipsForJudgeShow();
        }
        
        public System.Data.DataSet GetStartChipsByGameID(int gameID) {
            return base.Channel.GetStartChipsByGameID(gameID);
        }
        
        public System.Data.DataSet GetLastGameResultForLive() {
            return base.Channel.GetLastGameResultForLive();
        }
        
        public System.Data.DataSet GetGameResultByGameID(int gameID) {
            return base.Channel.GetGameResultByGameID(gameID);
        }
        
        public System.Data.DataSet GetPlayerChipsByRecordID(int recordID) {
            return base.Channel.GetPlayerChipsByRecordID(recordID);
        }
        
        public bool SetHeadPicture(int playerID, string headPicture) {
            return base.Channel.SetHeadPicture(playerID, headPicture);
        }
        
        public string GetPlayerChipsInPoolForLive(string chipsBet) {
            return base.Channel.GetPlayerChipsInPoolForLive(chipsBet);
        }
        
        public string GetChipsInPoolForLive(string chipsBet) {
            return base.Channel.GetChipsInPoolForLive(chipsBet);
        }
        
        public string GetChipsInPoolByGameID(int gameID, string chipsBet) {
            return base.Channel.GetChipsInPoolByGameID(gameID, chipsBet);
        }
        
        public int GetMaxBetChipsForLive() {
            return base.Channel.GetMaxBetChipsForLive();
        }
        
        public int GetTurnsBetChipsForNextPlayer(int playerID) {
            return base.Channel.GetTurnsBetChipsForNextPlayer(playerID);
        }
        
        public int GetTurnsLeftBetChipsForNextPlayer(int playerID) {
            return base.Channel.GetTurnsLeftBetChipsForNextPlayer(playerID);
        }
    }
}
