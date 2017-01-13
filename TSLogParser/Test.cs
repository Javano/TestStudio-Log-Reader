using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSLogParser
{
    class Test : TreeNode
    {
        private string name = string.Empty;
        private List<Test> steps = new List<Test>();
        private bool result = false;
        private Test parentRef;
  
        public List<Test> Steps
        {
            get
            {
                return steps;
            }
            set
            {
                steps = value;
            }
        }
        public bool Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }
        private string stepPattern = @"^'(\d{4}-\d{1,2}-\d{1,2} \d{1,2}:\d{1,2}:\d{1,2} (?:AM|PM))' - '(Pass|Fail|NotRun)' : (\d+\.) ([\s\S]+)$";

        public Test(string name, Test parentRef) : base(name)
        {
            this.name = name;
           // this.result = (result.Equals("Pass"));
            this.parentRef = parentRef;
          /*  foreach (string line in steps.Split('\n'))
            {
                this.steps.Add(line);
            }*/
        }

        public Test(string name) : this(name, null) { }

        public void parse(List<string> logLines)
        {
            string line = logLines.First();
            logLines.RemoveAt(0);

            while (logLines.Count > 0)
            {
                Test newTest;
                line = logLines.First();
                logLines.RemoveAt(0);

                if (String.IsNullOrWhiteSpace(line))
                {
                    //If line is empty, skip line
                }
                else if (line.Contains("<<<") && parentRef != null)
                {
                    parentRef.parse(logLines);
                }
                else if (line.Contains("InnerException:"))
                {
                    newTest = new Test("Exception:");
                    newTest.NodeFont = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
                    newTest.ForeColor = Color.Orange;
                    newTest.ImageIndex = 2;
                    newTest.SelectedImageIndex = 2;
                    Nodes.Add(newTest);
                    steps.Add(newTest);
                    newTest.Nodes.Add(logLines.First());
                    newTest.Nodes[newTest.Nodes.Count - 1].ForeColor = newTest.ForeColor;
                    logLines.RemoveAt(0);
                    while (logLines.First().TrimStart(' ').StartsWith("at "))
                    {
                        newTest.Nodes.Add(logLines.First());
                        newTest.Nodes[newTest.Nodes.Count-1].ForeColor = newTest.ForeColor;
                        logLines.RemoveAt(0);
                    }
                }
                else
                {
                    Match m = Regex.Match(line, stepPattern);
                    if (m.Success)
                    {
                        if (m.Groups[4].Value.Contains("Execute test") && logLines[1].Contains(">>>"))
                        {
                            newTest = new Test(m.Groups[3].Value +" " + m.Groups[4].Value, this);
                            Nodes.Add(newTest);
                            steps.Add(newTest);
                            logLines.RemoveAt(0);
                            newTest.parse(logLines);
                        } else
                        {
                            newTest = new Test(m.Groups[3].Value + " " + m.Groups[4].Value);
                            Nodes.Add(newTest);
                            steps.Add(newTest);
                        }

                        newTest.NodeFont = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
                        switch (m.Groups[2].Value)
                        {
                            case ("Pass"):
                                newTest.ForeColor = Color.Green;
                                newTest.ImageIndex = 1;
                                newTest.SelectedImageIndex = 1;
                                break;
                            case ("Fail"):
                                newTest.ForeColor = Color.Red;
                                newTest.ImageIndex = 3;
                                newTest.SelectedImageIndex = 3;
                                break;
                            case ("NotRun"):
                                newTest.ForeColor = Color.Gray;
                                newTest.ImageIndex = 4;
                                newTest.SelectedImageIndex = 4;
                                break;
                            default:
                                newTest.ForeColor = Color.Purple;
                                break;

                        }
                    } else
                    {
                        Nodes.Add(line);
                        steps.Add(new Test(line));
                    }
                    
                    
                }
            }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
