<<<<<<< HEAD
This is a Unity Project, version Unity 2019.3.15f1 (64-bit).
Code is in UnityProject/Assets/Scripts

Updates in Week5: 

1. Finished basic AI of enemy, pathfinding by A*, and used a finite state machine to manager the state of the enemy. 

2. UIs of enemies and player are finished, player has a level text, a health bar and a experience bar. Enemies have  a health bar. Flow uses challenge and abilities to measure the difficulty in games. In this project, the abilities can be represented as player's level and health points, challenge can be represented as enemies' number, health points, damage, speed and etc. And all these attributes will be used in the genetic algorithm to generate a level with a certain difficulty. 

  

  **此文档为本人伯明翰大学硕士毕设项目—Procedural Game Level Generation and Dynamic Difficulty Adjustment with Evolutionary Algorithm（暂定）的开发日志（说明）。此项目的主题为人工智能，所以在游戏的美术、设计等方面没有进行深入。该项目通过Unity引擎实现，编程语言为C#。**

   

  **1.**  **游戏设计**

  1.1 关卡地图

  此游戏的开发初衷为设计一款rougelike类型的俯视角射击游戏，游戏中关卡的地形和关卡的内容配置及其难度均由算法决定及生成。

  游戏地图以网格为单位，随机生成的地图以不同数量网格所组成的地面所拼接而成，如图1所示。

  ![img](file:///C:/Users/raven/AppData/Local/Temp/msohtmlclip1/01/clip_image001.png)

  图1 随机生成的地形

  因为在寻路程序中，A*算法需要建立网格系统，过多的地图需要一个大小较大的网格系统，会严重影响加载速度，最终关卡的地形采用了一个固定大小的矩形区域。

  1.2  玩家操作

  玩家可通过WASD操控人物移动，鼠标控制武器的射击方向，点击鼠标左键可发射子弹，如图2所示。

  ![img](file:///C:/Users/raven/AppData/Local/Temp/msohtmlclip1/01/clip_image003.jpg)

  图2 玩家操作

  1.3  玩家交互

  玩家具有血量条及经验条，击杀怪物可获得经验，升级后，血量上限提升，攻击力提升，下一次升级所需的经验也会提升。

  当场上没有敌人时，会生成传送门，玩家人物的碰撞器进入传送门的碰撞器后，玩家会进入下个关卡，此时场上会出现敌人，消灭全部敌人后会再次出现传送门。

  敌人的攻击方式与玩家相同，敌人武器的指向方向为玩家的位置，敌人的子弹击中玩家的碰撞器时，玩家会失去生命值，玩家及敌人的子弹击中地图边缘的墙壁后会消失，子弹击中子弹后不会消失。敌人攻击方式如图3所示。

  ![img](file:///C:/Users/raven/AppData/Local/Temp/msohtmlclip1/01/clip_image004.png)

  图3 敌人攻击

  1.4  敌人AI

  敌人的AI由一个简单的状态机所实现，如图4所示。敌人在生成后会在生成位置的附近位置内巡逻。

  巡逻的流程为：

  1．    在生成位置的附近随机取一个点。

  2．    使用寻路系统得到前往该点的路径。

  3．    敌人沿该路径行走，当离目标点的距离小于一个特定值时，再次生成一个点。

  4．    重复2-3。

  ![img](file:///C:/Users/raven/AppData/Local/Temp/msohtmlclip1/01/clip_image006.jpg)

  图4 敌人AI状态机

  A*算法的路线分为直线与对角线，当地图中有障碍物时，算法能够给出最短的路线，但此时障碍物的碰撞器与敌人的碰撞器会阻止怪物沿着此路线行走。因此在由A*得到该路线后，会再次对敌人周围是否有障碍物进行判断，同时判断路线中相邻节点的坐标偏移量，之后在路线中添加新节点，避免在周围有障碍物时出现对角线路线，如图5所示。

  ![img](file:///C:/Users/raven/AppData/Local/Temp/msohtmlclip1/01/clip_image008.jpg)   ![img](file:///C:/Users/raven/AppData/Local/Temp/msohtmlclip1/01/clip_image010.jpg)

  图5 改进后的路径

   

  **2.**  **人工智能**

  该项目希望通过人工智能来实现自动生成符合玩家技巧的难度的关卡。在心流理论中，玩家的体验由挑战及技巧组成。在该项目中，玩家的技巧可通过玩家的等级、生命值、完成关卡的时间等参数所表示，挑战可由敌人的数量、攻击力、生命值、攻击频率、子弹的飞行速度等参数所表示。关卡的难度可由玩家通过该关卡的概率所表示，在遗传算法中，可通过定制适应度公式，通过加入表示技巧及挑战的参数来模拟通过当前关卡的概率，在玩家成功通过关卡后，通过玩家在此关卡所花费的时间及损失的生命值来衡量其表现。根陈星汉老师的Flow in games论文中所提出动态化心流曲线，此项目希望通过一个动态权重系统来决定玩家下一个关卡的难度，例如当玩家完成了一个较为困难的关卡后，下一次关卡为中等难度或者简单难度的权重会高于困难关卡的权重，若下一次关卡依旧为困难难度，再下一次关卡的难度中困难关卡的权重会再次降低。

  **3.**  **开发进度**

  基本功能均已实现，正在调整适应度公式，项目代码量为上千行，没有使用任何插件及资源，游戏图形部分也由本人自己完成。

  项目预计完成时间：8月中旬

  论文预计完成时间：9月初

  

  

  This is a Unity Project, Unity version 2019.3.15f1 (64-bit).
  Code is in UnityProject/Assets/Scripts
>>>>>>> 361f0b0a1c1d51ffe3a1092324d8b992cdca6af4
