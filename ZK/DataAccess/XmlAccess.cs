using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Cn.Youdundianzi.Share.DataAccess
{
    public class XmlAccess
    {
        string filename = "KsAddress.xml";
        XmlDocument xmlDoc= new XmlDocument();
        public XmlAccess()
        {
            // 判断文件是否存在
            if (!File.Exists(filename))
            {
                xmlDoc = CreateXmlFile(filename);
            }
            else
            {
                xmlDoc.Load(filename);
            }
           
        }
       
        //创建Xml文件
        private XmlDocument CreateXmlFile(string filename)
        {
            xmlDoc = new XmlDocument();
            XmlNode root;

            XmlDeclaration declare = xmlDoc.CreateXmlDeclaration("1.0", "gb2312", null);
            xmlDoc.AppendChild(declare);
            root = xmlDoc.CreateElement("Kds");
            xmlDoc.AppendChild(root);
            xmlDoc.Save(filename);
            return xmlDoc;

        }

        #region 获取所有指定名称的节点
        /**/
        /// <summary>
        ///  功能:获取所有指定名称的节点(XmlNodeList)
        /// </summary>
        /// <param name="strNode">节点名称</param>
        /// <returns></returns>
        public XmlNodeList GetXmlNodeList(string strNodePath)
        {
            xmlDoc.Load(filename);
            XmlNodeList strReturn = null;
            try
            {
                XmlNodeList xmlNode = xmlDoc.SelectNodes(strNodePath);
                if (xmlNode != null)
                {
                    strReturn = xmlNode;
                }
            }
            catch (XmlException xmlEx)
            {
                throw xmlEx;
            }
            return strReturn;
        }
        #endregion

        #region 获取所有指定名称的节点
        /**/
        /// <summary>
        ///  功能:获取所有指定名称的节点(XmlNodeList)
        /// </summary>
        /// <param name="strNode">节点名称</param>
        /// <returns></returns>
        public static XmlNodeList GetXmlNodeList(string address,string strNodePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
          

            XmlNodeList strReturn = null;
            try
            {
                xmlDoc.Load(address);
                XmlNodeList xmlNode = xmlDoc.SelectNodes(strNodePath);
                if (xmlNode != null)
                {
                    strReturn = xmlNode;
                }
            }
            catch 
            {
                
            }
            return strReturn;
        }
        #endregion

        /*向一个已经存在的父节点中插入一个子节点,并返回子节点.*/
        /// <summary>
        /// 向一个已经存在的父节点中插入一个子节点,并返回子节点.
        /// </summary>
        /// <param name="parentNodePath">父节点</param>
        /// <param name="childnodename">字节点名称</param>
        /// <returns></returns>
        public XmlNode AddChildNode(string parentNodePath, string childnodename)
        {
            xmlDoc.Load(filename);
            XmlNode childXmlNode = null;
            try
            {
                XmlNode parentXmlNode = xmlDoc.SelectSingleNode(parentNodePath);
                if (parentXmlNode != null)
                {
                    childXmlNode = xmlDoc.CreateElement(childnodename);
                    parentXmlNode.AppendChild(childXmlNode);
                }
               
            }
            catch (XmlException xmle)
            {
                throw xmle;
            }
            xmlDoc.Save(filename);
            return childXmlNode;
        }

        /*向一个节点添加属性,并赋值*/
        /// <summary>
        /// 向一个节点添加属性,并赋值
        /// </summary>
        /// <param name="childXmlNode"></param>
        /// <param name="NodeAttribute"></param>
        /// <param name="NodeAttributeValue"></param>
        public void AddAttribute(XmlNode childXmlNode, string NodeAttribute, string NodeAttributeValue)
        {
            XmlAttribute nodeAttribute = this.xmlDoc.CreateAttribute(NodeAttribute);
            nodeAttribute.Value = NodeAttributeValue;
            childXmlNode.Attributes.Append(nodeAttribute);
            xmlDoc.Save(filename);
        }


        /* 根据指定xPath 查找指定节点是否存在*/
        /// <summary>
        ///  功能:获取所有指定名称的节点(XmlNodeList)
        /// </summary>
        /// <param name="strNode">节点名称</param>
        /// <returns></returns>
        public bool IsExist(string xPath)
        {

            xmlDoc.Load(filename);
            XmlNode node = xmlDoc.SelectSingleNode(xPath);
            if (node != null)
                return true;
            return false;
        }
      

        //根据网络流和路径返回指定节点的内容
       public static string GetTextByAddress(string address, string xpath)
       {   
            XmlDocument xmlDoc = new XmlDocument();
            string str = "";
            xmlDoc.Load(address);
            XmlNode node = xmlDoc.SelectSingleNode(xpath);
            if (node != null)
            {
                str = (node as XmlElement).InnerText;
            }
            return str;

        }

        // 删除节点
        public bool DeleteXmlNode(string XmlNodePath)
        {
            xmlDoc.Load(filename);
            XmlNodeList nodePath = this.xmlDoc.SelectNodes(XmlNodePath);
            if (!(nodePath == null))
            {
                foreach (XmlNode xn in nodePath)
                {
                    xn.ParentNode.RemoveChild(xn);
                }
                xmlDoc.Save(filename);
                return true;
            }
            else 
            {
                return false;
            }
        }


         public  void  Save()
        {
            xmlDoc.Save(filename);
          
        }


    }
}
