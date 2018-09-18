
namespace 上位机
{
    class LCDwidget
    {
        public int x { set; get; }//坐标
        public int y { set; get; }
        public string name { set; get; }//给arduino识别是什么控件
      //  public string text { set; get; }//要显示的文本

    }
    class Cpu :LCDwidget
    {
        public int core_num { set; get; }//核心数量
    }
    class Ram
    {
        public int all { set; get; }
        public int available { set; get; }
    }
}
