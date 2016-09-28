using System;


namespace Cn.Youdundianzi.Share.LEDDisplay
{
    public enum SelectDisplay
    {

        银特,//白鹿原、邙山桩考、中原桩考、公交公司、信阳
        泰伦,//杨凌、邙山路考、车管所
        泰伦毛家湾//四川毛家湾
    }

    public interface IDisplaycomm 
    {
      
        byte Speed { get; set; }//滚屏速度
        DisplayType Setdisplaytype{ get; set; }//显示牌类型：滚屏，直屏
      

        void ShowText(string txt);//显示
        void Close();//关闭
        
    }
}
