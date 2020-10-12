using System.Collections.Generic;
using static WeaponThread.WeaponStructure;
using static WeaponThread.WeaponStructure.WeaponDefinition;
using static WeaponThread.WeaponStructure.WeaponDefinition.AnimationDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AnimationDef.PartAnimationSetDef.EventTriggers;
using static WeaponThread.WeaponStructure.WeaponDefinition.AnimationDef.RelMove.MoveType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AnimationDef.RelMove;

namespace WeaponThread
{ // Don't edit above this line
    partial class Weapons
    {
        private AnimationDef BigBerthaAnimations => new AnimationDef
        {
            /*Emissives = new []
            {
                Emissive(
                    EmissiveName: "RGB", 
                    Colors: new []
                    {
                        Color(red:255, green: 0, blue:0, alpha: 1),//will transitions form one color to the next if more than one
                        Color(red:0, green: 255, blue:0, alpha: 1),
                        Color(red:0, green: 0, blue:255, alpha: 1),
                    }, 
                    IntensityFrom:1, //starting intensity, can be 0.0-1.0 or 1.0-0.0, setting both from and to, to the same value will stay at that value
                    IntensityTo:1, 
                    CycleEmissiveParts: false,//whether to cycle from one part to the next, while also following the Intensity Range, or set all parts at the same time to the same value
                    LeavePreviousOn: true,//true will leave last part at the last setting until end of animation, used with cycleEmissiveParts
                    EmissivePartNames: new []
                    {
                        "EmissiveName_01"
                    }),
            },*/


/* TOTAL TIMES
recoil: 450
open breech: 180
raise reloader: 360
load round: 120
drop reloader: 240
close door: 180
round reset: 60
total: 1590
*/


            WeaponAnimationSets = new[]
            {
                new PartAnimationSetDef() //barrel
                {
                    SubpartId = Names("Barrel"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        [Firing] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {
                                new RelMove //recoil back
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 90, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = ExpoDecay,
                                    //EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, 16), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
 
                                new RelMove  //return
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 240, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, -13), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
 
                               new RelMove 
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 200, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = ExpoDecay,
                                    //EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, -3), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },								
								
								
								
								
								
								
                            },
                    }
                },
                new PartAnimationSetDef() //reloader
                {
                    SubpartId = Names("Reloader"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,									//240 for recoil
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0),
                    Reverse = Events(),
                    Loop = Events(),
                   // ResetEmissives = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        [Reloading] =
                            new[] //Firing, Reloading, Overheated, Tracking, Locked, OnOff define a new[] for each
                            {
                                new RelMove //wait for breech door
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 180, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },



                                new RelMove  //raise the rack up
                                {

                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 360, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    //EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 5.4, 0), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },								
 



                                new RelMove //delay, wait for the round to load
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 120, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },

                                new RelMove  //drop the rack
                                {
 
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 240, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    //EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, -5.4, 0), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },								











                            },
                    }
                },
                new PartAnimationSetDef() //breech door
                {
                    SubpartId = Names("BreechDoor"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,									//240 for recoil
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0),
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        [Reloading] = new[] //Firing, Reloading, Overheated, Tracking, Locked, OnOff define a new[] for each
                        {
							//open door
                               new RelMove  
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 180, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(-90, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
 
 



                            new RelMove //wait for loading
                            {
                                CenterEmpty = "",
                                TicksToMove = 720, //360 for reloader, 120 for round, 240 drop reloader
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
 
 
 
 
 
 
 
                               new RelMove  //close the door
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 180, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(90, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
 				
                        },
                    }
                },
                new PartAnimationSetDef() //round
                {
                    SubpartId = Names("round"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,									//240 for recoil
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0),
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        [Reloading] = new[] //Firing, Reloading, Overheated, Tracking, Locked, OnOff define a new[] for each
                        {
							//waiting for breech door
 							
                           new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 180, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
							
							//Wait for reloader rack
                           new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 360, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },

							//load the round
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 100, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0, 17), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },

                            //mirror the (parent) reloader closing to appear stationary
                               new RelMove  //raise the rack up
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 120, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = ExpoGrowth,
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 2.7, 0), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                                new RelMove 
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 120, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = ExpoDecay,
                                    //EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 2.7, 0), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },								                            
 
 
 
 
 
							//wait for door
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 180, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide,
                                Fade = false,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
							//reset to new position
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, -9.4, -17), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show,
                                Fade = true,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                           new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 120, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 4, 0), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },							
                        },
                    }
                }
				
				
            }
        };
    }
}
