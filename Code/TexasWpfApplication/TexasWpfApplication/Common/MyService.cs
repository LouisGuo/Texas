using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TexasWpfApplication.Common
{
    class MyService
    {
        public MyService()
        {
            
        }

        public ServiceAdministrator.AdministratorSoapClient GetAdministrator()
        {
            
            return new ServiceAdministrator.AdministratorSoapClient("AdministratorSoap", "http://"+App.ip+"/Api/Administrator.asmx");
        }

        public ServiceBet.BetSoapClient GetBet()
        {
            return new ServiceBet.BetSoapClient("BetSoap", "http://" + App.ip + "/Api/Bet.asmx");
        }

        public ServiceCard.CardSoapClient GetCard()
        {
            return new ServiceCard.CardSoapClient("CardSoap", "http://" + App.ip + "/Api/Card.asmx");
        }

        public ServicePlayerChip.PlayerChipSoapClient GetPlayerChip()
        {
            return new ServicePlayerChip.PlayerChipSoapClient("PlayerChipSoap", "http://" + App.ip + "/Api/PlayerChip.asmx");
        }

        public ServiceRecord.RecordSoapClient GetRecord()
        {
            return new ServiceRecord.RecordSoapClient("RecordSoap", "http://" + App.ip + "/Api/Record.asmx");
        }

        public ServiceGame.GameSoapClient GetGame()
        {
            return new ServiceGame.GameSoapClient("GameSoap", "http://" + App.ip + "/Api/Game.asmx");
        }
    }
}
