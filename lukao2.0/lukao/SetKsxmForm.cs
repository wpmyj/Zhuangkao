using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace lukao
{
    public partial class SetKsxmForm : Form
    {
        public ModuleSettings settings;

        ArrayList selectlist;
        ArrayList noselectlist;

        public SetKsxmForm(ModuleSettings settings)
        {
            InitializeComponent();
            this.settings = settings;
            selectlist = new ArrayList();
            noselectlist = new ArrayList();
            string[] allxm = { "6:连续障碍", "2:单边桥", "4:直角转弯", "1:侧方位停车", "0:坡道起步", "5:限速通过限宽门", "7:百米加减挡", "8:起伏路驾驶", "3:曲线行驶" };
              string[] str = settings.DevInfo.Split(',');
              if (settings.DevInfo != string.Empty)
              {

                  for (int i = 0; i < str.Length; i++)
                  {
                      listBox2.Items.Add(str[i].Substring(1, str[i].Length - 1));
                  }

                  bool tmpbool = true;
                  for (int i = 0; i < allxm.Length; i++)
                  {
                      tmpbool = true;
                      for (int j = 0; j < str.Length; j++)
                      {
                          tmpbool = tmpbool && (allxm[i].CompareTo(str[j].Substring(1)) != 0);


                      }
                      if (tmpbool)
                      {
                          listBox1.Items.Add(allxm[i]);
                      }

                  }
              }
              else
              {
                  for (int i = 0; i < allxm.Length; i++)
                  {
                      listBox1.Items.Add(allxm[i]);
                  }
              }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count > 0)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count > 1)
            {
                if (listBox2.SelectedIndex > 0)
                {
                    int tmpindex = listBox2.SelectedIndex;
                    string tmpstr = listBox2.SelectedItem.ToString();
                    listBox2.Items.Remove(listBox2.SelectedItem);
                    listBox2.Items.Insert(tmpindex - 1,tmpstr);
                    listBox2.SetSelected(tmpindex - 1, true);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             string tmpstr = "";
             if (listBox2.Items.Count > 0)
             {
                 tmpstr = domainUpDown1.Text +listBox2.Items[0];
                 for (int i = 1; i < listBox2.Items.Count; i++)
                 {
                     tmpstr = tmpstr + "," + domainUpDown1.Text  +  listBox2.Items[i];
                 }
                 settings.DevInfo = tmpstr;
                 ModuleConfig.SaveSettings(settings);
             }
        }
        


    }
}