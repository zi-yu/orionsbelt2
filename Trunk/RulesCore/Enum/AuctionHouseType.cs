using System;

namespace OrionsBelt.RulesCore.Enum {
    [Flags]
	public enum AuctionHouseType 
    {   
        None = 0,
        Intrinsic = 1,  
        Rare = 2,        
        Ship = 4,
        Light = 8,
        Medium = 16,
        Heavy = 32,
        Ultimate = 64,
        Human = 128,
        DarkHuman = 256,
        Bugs = 512,
        Boss = 1024
    };
}
