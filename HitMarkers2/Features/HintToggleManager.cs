using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitMarkers2.Features {
    public static class HintToggleManager { 
        public static Dictionary<string, bool> po { get; set; } = new Dictionary<string, bool>();
        public static bool ige { get; set; } 
        internal static void domagicthing(Config _config)
        {
            ige = _config.AreHintsEnabled; 
            po.Clear(); 
        }
        public static void ee(string ud = null) { 
            if (ud == null) 
            { 
                ige = true; return; 
            } 
            if (!po.ContainsKey(ud)) 
            { po.Add(ud, true); 
                return; 
            } 
            po[ud] = true; 
        }
        public static void de(string ud = null) 
        {
            if (ud == null) 
            {
                ige = false; return; 
            }
            if (!po.ContainsKey(ud)) 
            { 
                po.Add(ud, false); 
                return; 
            } 
            po[ud] = false; 
        }
        public static bool ok(string UserID) 
        {
            if (po.ContainsKey(UserID)) 
            {
                return po[UserID]; 
            } 
            return ige; 
        } 
    } 
}