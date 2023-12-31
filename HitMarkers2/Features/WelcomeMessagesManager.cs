﻿using System;

namespace HitMarkers2
{
    public static class WelcomeMessagesManager
    {
        #region Messages

        public static string Default => @"
██╗░░██╗██╗████████╗███╗░░░███╗░█████╗░██████╗░██╗░░██╗███████╗██████╗░░██████╗  ██████╗░
██║░░██║██║╚══██╔══╝████╗░████║██╔══██╗██╔══██╗██║░██╔╝██╔════╝██╔══██╗██╔════╝  ╚════██╗
███████║██║░░░██║░░░██╔████╔██║███████║██████╔╝█████═╝░█████╗░░██████╔╝╚█████╗░  ░░███╔═╝
██╔══██║██║░░░██║░░░██║╚██╔╝██║██╔══██║██╔══██╗██╔═██╗░██╔══╝░░██╔══██╗░╚═══██╗  ██╔══╝░░
██║░░██║██║░░░██║░░░██║░╚═╝░██║██║░░██║██║░░██║██║░╚██╗███████╗██║░░██║██████╔╝  ███████╗
╚═╝░░╚═╝╚═╝░░░╚═╝░░░╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═════╝░  ╚══════╝
                                                                    █░█   ▀█ ░ ▄█ ░ ▀█
                                                                    ▀▄▀   █▄ ▄ ░█ ▄ █▄";
        public static string DefaultDebug => @"
██╗░░██╗██╗████████╗███╗░░░███╗░█████╗░██████╗░██╗░░██╗███████╗██████╗░░██████╗  ██████╗░
██║░░██║██║╚══██╔══╝████╗░████║██╔══██╗██╔══██╗██║░██╔╝██╔════╝██╔══██╗██╔════╝  ╚════██╗
███████║██║░░░██║░░░██╔████╔██║███████║██████╔╝█████═╝░█████╗░░██████╔╝╚█████╗░  ░░███╔═╝
██╔══██║██║░░░██║░░░██║╚██╔╝██║██╔══██║██╔══██╗██╔═██╗░██╔══╝░░██╔══██╗░╚═══██╗  ██╔══╝░░
██║░░██║██║░░░██║░░░██║░╚═╝░██║██║░░██║██║░░██║██║░╚██╗███████╗██║░░██║██████╔╝  ███████╗
╚═╝░░╚═╝╚═╝░░░╚═╝░░░╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═════╝░  ╚══════╝
█▀▄ █▀▀ █▄▄ █░█ █▀▀ █▀▄▀█ █▀█ █▀▄ █▀▀                                █░█   ▀█ ░ ▄█ ░ ▀█
█▄▀ ██▄ █▄█ █▄█ █▄█ █░▀░█ █▄█ █▄▀ ██▄                                ▀▄▀   █▄ ▄ ░█ ▄ █▄";
        public static string EasterEgg => @"
██╗░░██╗██╗░░░██╗██████╗░███████╗███╗░░░███╗░█████╗░██████╗░██╗░░██╗███████╗██████╗░░██████╗  ██████╗░
██║░░██║██║░░░██║██╔══██╗██╔════╝████╗░████║██╔══██╗██╔══██╗██║░██╔╝██╔════╝██╔══██╗██╔════╝  ╚════██╗
███████║██║░░░██║██████╦╝█████╗░░██╔████╔██║███████║██████╔╝█████═╝░█████╗░░██████╔╝╚█████╗░  ░░███╔═╝
██╔══██║██║░░░██║██╔══██╗██╔══╝░░██║╚██╔╝██║██╔══██║██╔══██╗██╔═██╗░██╔══╝░░██╔══██╗░╚═══██╗  ██╔══╝░░
██║░░██║╚██████╔╝██████╦╝███████╗██║░╚═╝░██║██║░░██║██║░░██║██║░╚██╗███████╗██║░░██║██████╔╝  ███████╗
╚═╝░░╚═╝░╚═════╝░╚═════╝░╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═════╝░  ╚══════╝
                                                                                 █░█   ▀█ ░ ▄█ ░ ▀█
                                                                                 ▀▄▀   █▄ ▄ ░█ ▄ █▄";
        public static string EasterEggDebug => @"
██╗░░██╗██╗░░░██╗██████╗░███████╗███╗░░░███╗░█████╗░██████╗░██╗░░██╗███████╗██████╗░░██████╗  ██████╗░
██║░░██║██║░░░██║██╔══██╗██╔════╝████╗░████║██╔══██╗██╔══██╗██║░██╔╝██╔════╝██╔══██╗██╔════╝  ╚════██╗
███████║██║░░░██║██████╦╝█████╗░░██╔████╔██║███████║██████╔╝█████═╝░█████╗░░██████╔╝╚█████╗░  ░░███╔═╝
██╔══██║██║░░░██║██╔══██╗██╔══╝░░██║╚██╔╝██║██╔══██║██╔══██╗██╔═██╗░██╔══╝░░██╔══██╗░╚═══██╗  ██╔══╝░░
██║░░██║╚██████╔╝██████╦╝███████╗██║░╚═╝░██║██║░░██║██║░░██║██║░╚██╗███████╗██║░░██║██████╔╝  ███████╗
╚═╝░░╚═╝░╚═════╝░╚═════╝░╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═════╝░  ╚══════╝
█▀▄ █▀▀ █▄▄ █░█ █▀▀ █▀▄▀█ █▀█ █▀▄ █▀▀                                              █░█   ▀█ ░ ▄█ ░ ▀█
█▄▀ ██▄ █▄█ █▄█ █▄█ █░▀░█ █▄█ █▄▀ ██▄                                              ▀▄▀   █▄ ▄ ░█ ▄ █▄";
        public static string Halloween => @"
 ██░ ██  ██▓▄▄▄█████▓ ███▄ ▄███▓ ▄▄▄       ██▀███   ██ ▄█▀▓█████  ██▀███    ██████    
▓██░ ██▒▓██▒▓  ██▒ ▓▒▓██▒▀█▀ ██▒▒████▄    ▓██ ▒ ██▒ ██▄█▒ ▓█   ▀ ▓██ ▒ ██▒▒██    ▒    
▒██▀▀██░▒██▒▒ ▓██░ ▒░▓██    ▓██░▒██  ▀█▄  ▓██ ░▄█ ▒▓███▄░ ▒███   ▓██ ░▄█ ▒░ ▓██▄      
░▓█ ░██ ░██░░ ▓██▓ ░ ▒██    ▒██ ░██▄▄▄▄██ ▒██▀▀█▄  ▓██ █▄ ▒▓█  ▄ ▒██▀▀█▄    ▒   ██▒   
░▓█▒░██▓░██░  ▒██▒ ░ ▒██▒   ░██▒ ▓█   ▓██▒░██▓ ▒██▒▒██▒ █▄░▒████▒░██▓ ▒██▒▒██████▒▒   
 ▒ ░░▒░▒░▓    ▒ ░░   ░ ▒░   ░  ░ ▒▒   ▓▒█░░ ▒▓ ░▒▓░▒ ▒▒ ▓▒░░ ▒░ ░░ ▒▓ ░▒▓░▒ ▒▓▒ ▒ ░   
 ▒ ░▒░ ░ ▒ ░    ░    ░  ░      ░  ▒   ▒▒ ░  ░▒ ░ ▒░░ ░▒ ▒░ ░ ░  ░  ░▒ ░ ▒░░ ░▒  ░ ░   
 ░  ░░ ░ ▒ ░  ░      ░      ░     ░   ▒     ░░   ░ ░ ░░ ░    ░     ░░   ░ ░  ░  ░     
 ░  ░  ░ ░                  ░         ░  ░   ░     ░  ░      ░  ░   ░           ░     ";
        public static string Christmas => @"
       __
    .-'  |
   /   <\|        ██╗░░██╗██╗████████╗███╗░░░███╗░█████╗░██████╗░██╗░░██╗███████╗██████╗░░██████╗  ██████╗░
  /     \'        ██║░░██║██║╚══██╔══╝████╗░████║██╔══██╗██╔══██╗██║░██╔╝██╔════╝██╔══██╗██╔════╝  ╚════██╗
  |_.- o-o        ███████║██║░░░██║░░░██╔████╔██║███████║██████╔╝█████═╝░█████╗░░██████╔╝╚█████╗░  ░░███╔═╝
  / C  -._)\      ██╔══██║██║░░░██║░░░██║╚██╔╝██║██╔══██║██╔══██╗██╔═██╗░██╔══╝░░██╔══██╗░╚═══██╗  ██╔══╝░░
 /',        |     ██║░░██║██║░░░██║░░░██║░╚═╝░██║██║░░██║██║░░██║██║░╚██╗███████╗██║░░██║██████╔╝  ███████╗
|   `-,_,__,'     ╚═╝░░╚═╝╚═╝░░░╚═╝░░░╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═════╝░  ╚══════╝
(,,)====[_]=|                                                                         █░█   ▀█ ░ ▄█ ░ ▀█
  '.   ____/                                                                          ▀▄▀   █▄ ▄ ░█ ▄ █▄
   | -|-|_
   |____)_)";
        public static string ChristmasDebug => @"
       __
    .-'  |
   /   <\|        ██╗░░██╗██╗████████╗███╗░░░███╗░█████╗░██████╗░██╗░░██╗███████╗██████╗░░██████╗  ██████╗░
  /     \'        ██║░░██║██║╚══██╔══╝████╗░████║██╔══██╗██╔══██╗██║░██╔╝██╔════╝██╔══██╗██╔════╝  ╚════██╗
  |_.- o-o        ███████║██║░░░██║░░░██╔████╔██║███████║██████╔╝█████═╝░█████╗░░██████╔╝╚█████╗░  ░░███╔═╝
  / C  -._)\      ██╔══██║██║░░░██║░░░██║╚██╔╝██║██╔══██║██╔══██╗██╔═██╗░██╔══╝░░██╔══██╗░╚═══██╗  ██╔══╝░░
 /',        |     ██║░░██║██║░░░██║░░░██║░╚═╝░██║██║░░██║██║░░██║██║░╚██╗███████╗██║░░██║██████╔╝  ███████╗
|   `-,_,__,'     ╚═╝░░╚═╝╚═╝░░░╚═╝░░░╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═════╝░  ╚══════╝
(,,)====[_]=|     █▀▄ █▀▀ █▄▄ █░█ █▀▀ █▀▄▀█ █▀█ █▀▄ █▀▀                                 █░█   ▀█ ░ ▄█ ░ ▀█
  '.   ____/      █▄▀ ██▄ █▄█ █▄█ █▄█ █░▀░█ █▄█ █▄▀ ██▄                                 ▀▄▀   █▄ ▄ ░█ ▄ █▄
   | -|-|_
   |____)_)";

        #endregion

        public static string GetWelcomeMessage(bool isDebug = false)
        {
            var isEasterEgg = UnityEngine.Random.Range(1, 10) == 10;
            var curMonth = DateTime.Today.Month;

            if (isDebug)
            {
                return isEasterEgg ? EasterEggDebug
                    : curMonth == 12 ? ChristmasDebug
                    : DefaultDebug;
            }

            return isEasterEgg ? EasterEgg
                : curMonth == 10 ? Halloween
                : curMonth == 12 ? Christmas
                : Default;
        }
    }
}
