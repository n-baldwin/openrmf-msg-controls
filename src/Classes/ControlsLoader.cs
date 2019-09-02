using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using openrmf_msg_controls.Models;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace openrmf_msg_controls.Classes {

    public static class ControlsLoader {

        public static List<Control> LoadControls() {
            List<Control> controls = new List<Control>();
            Control c;
            ChildControl cc;
            XmlDocument xmlDoc = new XmlDocument();
            XmlNodeList statementList;
            // get the file path for the NIST control listing inside this area
            var ccipath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/800-53-controls.xml";
            if (File.Exists(ccipath)) {
                xmlDoc.LoadXml(File.ReadAllText(ccipath));
                XmlNodeList itemList = xmlDoc.GetElementsByTagName("controls:control");
                foreach (XmlElement child in itemList) {
                    c = new Control();
                    foreach (XmlElement controlData in child.ChildNodes) {
                        if (controlData.Name == "family")
                            c.family = controlData.InnerText;
                        else if (controlData.Name == "number")
                            c.number = controlData.InnerText;
                        else if (controlData.Name == "title")
                            c.title = controlData.InnerText;
                        else if (controlData.Name == "priority")
                            c.priority = controlData.InnerText;
                        else if (controlData.Name == "baseline-impact") {
                            if (controlData.InnerText == "LOW")
                                c.lowimpact = true;
                            else if (controlData.InnerText == "MODERATE")
                                c.moderateimpact = true;
                            else if (controlData.InnerText == "HIGH")
                                c.highimpact = true;
                        }
                        else if (controlData.Name == "statement") {
                            // get the subparts of this control
                            statementList = controlData.GetElementsByTagName("statement");
                            foreach (XmlElement statementChild in statementList) {
                                cc = new ChildControl();
                                // get all the sub controls listed
                                foreach (XmlElement statementData in statementChild.ChildNodes) {
                                    if (statementData.Name == "number")
                                        cc.number = statementData.InnerText;
                                    else if (statementData.Name == "description")
                                        cc.description = statementData.InnerText;
                                }
                                c.childControls.Add(cc);
                            }
                        }
                        else if (controlData.Name == "control-enhancements") {
                            // get the subparts of this control enhancement section
                            statementList = controlData.GetElementsByTagName("control-enhancement");
                            foreach (XmlElement statementChild in statementList) {
                                cc = new ChildControl();
                                // get all the sub controls listed
                                foreach (XmlElement statementData in statementChild.ChildNodes) {
                                    if (statementData.Name == "number")
                                        cc.number = statementData.InnerText;
                                    else if (statementData.Name == "title")
                                        cc.description = statementData.InnerText;
                                }
                                c.childControls.Add(cc);
                            }
                        }
                        else if (controlData.Name == "supplemental-guidance") {
                            // get the description
                            if (controlData.ChildNodes.Count > 0) {
                                c.supplementalGuidance = controlData.ChildNodes[0].FirstChild.InnerText.Replace("\r","").Replace("\n", "");
                            }
                        }
                    }
                    controls.Add(c); // add to the main control
                }
            }
            // ChildControl cc = new ChildControl();
            // cc.number = "AC-1a";
            // cc.description = "Develops, documents, and disseminates to [Assignment: organization-defined personnel or roles]";
            // c.childControls.Add(cc);
            // cc.number = "AC-1a1";
            // cc.description = "An access control policy that addresses purpose, scope, roles, responsibilities, management commitment, coordination among organizational entities, and compliance";
            // c.childControls.Add(cc);
            // save it 

            return controls; // send back and have them cycle through it
        }
    }

}