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
            // �ж��ļ��Ƿ����
            if (!File.Exists(filename))
            {
                xmlDoc = CreateXmlFile(filename);
            }
            else
            {
                xmlDoc.Load(filename);
            }
           
        }
       
        //����Xml�ļ�
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

        #region ��ȡ����ָ�����ƵĽڵ�
        /**/
        /// <summary>
        ///  ����:��ȡ����ָ�����ƵĽڵ�(XmlNodeList)
        /// </summary>
        /// <param name="strNode">�ڵ�����</param>
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

        #region ��ȡ����ָ�����ƵĽڵ�
        /**/
        /// <summary>
        ///  ����:��ȡ����ָ�����ƵĽڵ�(XmlNodeList)
        /// </summary>
        /// <param name="strNode">�ڵ�����</param>
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

        /*��һ���Ѿ����ڵĸ��ڵ��в���һ���ӽڵ�,�������ӽڵ�.*/
        /// <summary>
        /// ��һ���Ѿ����ڵĸ��ڵ��в���һ���ӽڵ�,�������ӽڵ�.
        /// </summary>
        /// <param name="parentNodePath">���ڵ�</param>
        /// <param name="childnodename">�ֽڵ�����</param>
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

        /*��һ���ڵ��������,����ֵ*/
        /// <summary>
        /// ��һ���ڵ��������,����ֵ
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


        /* ����ָ��xPath ����ָ���ڵ��Ƿ����*/
        /// <summary>
        ///  ����:��ȡ����ָ�����ƵĽڵ�(XmlNodeList)
        /// </summary>
        /// <param name="strNode">�ڵ�����</param>
        /// <returns></returns>
        public bool IsExist(string xPath)
        {

            xmlDoc.Load(filename);
            XmlNode node = xmlDoc.SelectSingleNode(xPath);
            if (node != null)
                return true;
            return false;
        }
      

        //������������·������ָ���ڵ������
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

        // ɾ���ڵ�
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
