# Toolbox

![Image](https://i.imgur.com/WAEzk68.png)

Update of Nifs mod
https://steamcommunity.com/sharedfiles/filedetails/?id=2016186459

![Image](https://i.imgur.com/7Gzt3Rg.png)

	
![Image](https://i.imgur.com/NOW7jU1.png)

![Image](https://i.imgur.com/pLIIppn.png)

ToolBox is an XML based framework, designed for making mod settings that allow changes to ThingDef properties. Examples: cost, hitpoints, beauty, etc. It can also be used to provide a guide or information regarding your mod. It currently has 11 property widgets that can be applied to a ThingDef, and will continue to expand in the future.

Note: the settings will appear inside of the ToolBox settings. It does not act as an independent setting.

![Image](https://i.imgur.com/ZQrScUl.png)

https://github.com/Nif-kun/ToolBox/wiki] Github Wiki (Updated for v1.0.2.2)


![Image](https://i.imgur.com/bCAtkVT.png)

»Minor Update (v1.0.2.3) [08/11/20]
-Added 1.2 in supported versions

»Minor Update (v1.0.2.2) [04/07/20]
-Added &lt;terrainCol&gt; for creating TerrainAffordanceNeeded option button.

»Minor Update (v1.0.1.2) [03/10/20]
-SettingsDef level default is now Middle.
-Any LinkFlags that already exists will not be added in the listOptions.
-Added &lt;label&gt; in &lt;thingList&gt;. It will replace the collected ThingDef label/name and allow custom labels.
-&lt;label&gt; for &lt;textBox&gt; now has an option to center text: (bool)&lt;center&gt;.
-Added &lt;line&gt; which creates a line depending on lineType: Vertical or Horizontal.

»Build update (v1.0.0.2) [03/07/20]
-Changed the default min of beautyCol to -99999 instead of -9999.


![Image](https://i.imgur.com/UUqdkMB.png)

Any mod that does not have any modifiable ThingDef should be fine. And if it does, the level of incompatibility may depend on the mod placement. It is advised to use a mod&apos;s default mod setting, instead of making one using ToolBox. Issues may occur if the two mods are changing the same property of a ThingDef. It will either pick one over the other or simply not change at all.


![Image](https://i.imgur.com/9mpk8FJ.png)

Q1: Is this compatible with RIMMSqol?
A1: Yes, as long as you&apos;re not modifying both of the same property of a ThingDef.


![Image](https://i.imgur.com/RfFm9v4.png)

»https://steamcommunity.com/sharedfiles/filedetails/?id=2050680665]Architect Expanded - Fences
»https://steamcommunity.com/sharedfiles/filedetails/?id=2021234555]Gizmo Begone!


![Image](https://i.imgur.com/ghttZNv.png)

»https://github.com/Nif-kun/ToolBox]Github upload

https://ko-fi.com/nifity#]![Image](https://i.imgur.com/ac3XaOI.png)

https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=NUYHNTAMU88U6&source]![Image](https://i.imgur.com/UxwY8Uz.gif)

![Image](https://i.imgur.com/p7Fv1Z6.gif)


![Image](https://i.imgur.com/Rs6T6cr.png)



-  See if the the error persists if you just have this mod and its requirements active.
-  If not, try adding your other mods until it happens again.
-  Post your error-log using https://steamcommunity.com/workshop/filedetails/?id=818773962]HugsLib and command Ctrl+F12
-  For best support, please use the Discord-channel for error-reporting.
-  Do not report errors by making a discussion-thread, I get no notification of that.
-  If you have the solution for a problem, please post it to the GitHub repository.



