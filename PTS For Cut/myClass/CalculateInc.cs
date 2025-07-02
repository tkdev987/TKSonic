using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PTS_For_Cut._9_1Inc;
using PTS_For_Cut.Myclass;

namespace PTS_For_Cut.myClass
{
    internal class CalculateInc
    {
        public static string stepEff(string st, int rate)
        {
            double cv = 0;
            string tb = String.Format("{0:0.00}", double.Parse(st)); //tbEffSale.Text.ToString("#.##");

            for (int i = 0; i < tb.Length; i++)
            {

                //MessageBox.Show(tbEffSale.Text.Substring(i, 1));
                if (tb.Substring(i, 1) == ".")
                {
                    if (rate == 10)
                    {
                        if (i == 2)
                        {
                            string up = tb.Substring(0, 1) + "0";
                            cv = double.Parse(up) + 10.00;
                        }
                        else if (i == 3)
                        {
                            string up = tb.Substring(0, 2) + "0";
                            cv = double.Parse(up) + 10.00;
                        }
                    }
                    else
                    {
                        if (double.Parse(tb.Substring(i - 1, 4)) > 4.99)
                        {
                            if (i == 2)
                            {
                                string up = tb.Substring(0, 1) + "0";
                                cv = double.Parse(up) + 10.00;
                            }
                            else if (i == 3)
                            {
                                string up = tb.Substring(0, 2) + "0";
                                cv = double.Parse(up) + 10.00;
                            }

                        }
                        else if (double.Parse(tb.Substring(i - 1, 4)) < 5)
                        {
                            if (i == 2)
                            {
                                string up = tb.Substring(0, 1) + "0";
                                cv = double.Parse(up) + 5;
                            }
                            else if (i == 3)
                            {
                                string up = tb.Substring(0, 2) + "0";
                                cv = double.Parse(up) + 5;
                            }
                        }
                    }


                }

            }
            return cv.ToString();
        }


        public static string setActualEff(string st, int rate)
        {
            double cv = 0;
            string tb = String.Format("{0:0.00}", double.Parse(st)); //tbEffSale.Text.ToString("#.##");

            for (int i = 0; i < tb.Length; i++)
            {

                //MessageBox.Show(tbEffSale.Text.Substring(i, 1));



                if (tb.Substring(i, 1) == ".")
                {
                    if (rate == 10)
                    {
                        if (i == 2)
                        {
                            string up = tb.Substring(0, 1) + "0";
                            cv = double.Parse(up);
                        }
                        else if (i == 3)
                        {
                            string up = tb.Substring(0, 2) + "0";
                            cv = double.Parse(up);
                        }
                    }
                    else
                    {
                        if (double.Parse(tb.Substring(i - 1, 4)) > 4.99)
                        {
                            if (i == 2)
                            {
                                string up = tb.Substring(0, 1) + "0";
                                cv = double.Parse(up) + 5;
                            }
                            else if (i == 3)
                            {
                                string up = tb.Substring(0, 2) + "0";
                                cv = double.Parse(up) + 5;
                            }

                        }
                        else if (double.Parse(tb.Substring(i - 1, 4)) < 5)
                        {
                            if (i == 2)
                            {
                                string up = tb.Substring(0, 1) + "0";
                                cv = double.Parse(up);
                            }
                            else if (i == 3)
                            {
                                string up = tb.Substring(0, 2) + "0";
                                cv = double.Parse(up);
                            }
                        }



                    }
                }

            }
            return cv.ToString();
        }


        public static string[] CompareEff(string st, string ef, double hr, string NameDBtb, int stepUpRate)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string[] resultTurn = { };
            resultTurn = resultTurn.Append("").ToArray();
            resultTurn = resultTurn.Append("").ToArray();
            resultTurn = resultTurn.Append("").ToArray();
            resultTurn = resultTurn.Append("").ToArray();

            string Price = "";
            string PriceInc = "";
            string SAM = "";
            string EffSale = "";
            string Operator = "";
            string Output = "";
            string EmpInc = "";
            string LineLeadInc = "";
            string SupInc = "";
            //---------------------------------------------------------------------------------------------------getData
            ConnectMySQL.db = "incentive_db";
            MySqlConnection connection = ConnectMySQL.GetConnection();
            string sql = "SELECT `Price`, `IncPrice`, `SAM`,  `EffSale`, `Operator`, `Output`," +
                "`EmpInc`,`LineLeadInc`, `SupInc`  FROM `" + NameDBtb + "` WHERE `Style`= '" + st + "' ";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            MySqlDataReader myReder;

            try
            {
                myReder = cmd.ExecuteReader();
                while (myReder.Read())
                {
                    //lbSubNo.Text     = myReder.GetString(0);
                    Price = myReder.GetString(0);
                    PriceInc = myReder.GetString(1);
                    SAM = myReder.GetString(2);
                    // tbSmvCustomer.Text = myReder.GetString(3);
                    EffSale = myReder.GetString(3);
                    Operator = myReder.GetString(4);
                    Output = myReder.GetString(5);
                    EmpInc = myReder.GetString(6);
                    LineLeadInc = myReder.GetString(7);
                    SupInc = myReder.GetString(8);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            connection.Close();

            //----------------------------------------------------------------------------------Cal
            if (st != "" && Price != "" && PriceInc != "" && SAM != "" && EffSale != "" && Operator != "" && EmpInc != "" && LineLeadInc != "" && SupInc != "")
            {
                string ts = stepEff(EffSale, stepUpRate);

                double Eff = double.Parse(ts);

                double sam = double.Parse(SAM);

                double Oper = double.Parse(Operator);

                double price = double.Parse(Price);

                double priceInc = double.Parse(PriceInc);


                dt.Columns.Add("eff");
                dt.Columns.Add("emp");
                dt.Columns.Add("Lead");
                dt.Columns.Add("Sup");
                double OH =  double.Parse(IncentiveReport.ins.Overhead);
                double wage = double.Parse(IncentiveReport.ins.Wage);

                for (int i = 1; i < 14; i++)
                {
                    if (i == 1)
                    {
                        //tbOH.Text = FirstPage.ins.OverHead;
                        //tbWage.Text = FirstPage.ins.Wage;

                        double QTY = (Eff / 100 * 8 * 60 * Oper) / sam;
                        double income = QTY * price;
                        double expenses = Oper * wage * OH;
                        double balance = income - expenses;
                        double profitPer = (balance / income) * 100;
                        double THB = (income - (priceInc * QTY)) / Oper;
                        // 
                        //string sTHB = ((int)Math.Ceiling(THB)).ToString();
                        //string sQTY = ((int)Math.Ceiling(QTY)).ToString();
                        //string sprofitPer = ((int)Math.Ceiling(profitPer)).ToString();
                        string sTHB = THB.ToString("0.00");
                        string sQTY = QTY.ToString("0.00");
                        string sprofitPer = profitPer.ToString("0.00");

                        double empInc = double.Parse(sTHB) * double.Parse(EmpInc) / 100;
                        double LineLead = double.Parse(sTHB) * double.Parse(LineLeadInc) / 100;
                        double Super = double.Parse(sTHB) * double.Parse(SupInc) / 100;
                        //gvDis.Rows.Add(i, ts, sTHB, sQTY, sprofitPer, empInc.ToString("0.00"), LineLead.ToString("0.00"), Super.ToString("0.00"));

                        dt.Rows.Add(ts, empInc.ToString("0.00"), LineLead.ToString("0.00"), Super.ToString("0.00"));


                    }
                    else
                    {

                        double eff = double.Parse(dt.Rows[i - 2][0].ToString()) + stepUpRate;
                        // double ef = double.Parse(gvDis.Rows[i-1].Cells[1].Value.ToString());
                        double QTY = (eff / 100 * 8 * 60 * Oper) / sam;
                        double income = QTY * price;
                        double expenses = Oper * wage * OH;
                        double balance = income - expenses;
                        double profitPer = (balance / income) * 100;
                        double THB = (income - (priceInc * QTY)) / Oper;
                        // 
                        //string sTHB = ((int)Math.Ceiling(THB)).ToString();
                        //string sQTY = ((int)Math.Ceiling(QTY)).ToString();
                        //string sprofitPer = ((int)Math.Ceiling(profitPer)).ToString();
                        string sTHB = THB.ToString("0.00");
                        string sQTY = QTY.ToString("0.00");
                        string sprofitPer = profitPer.ToString("0.00");

                        double empInc = double.Parse(sTHB) * double.Parse(EmpInc) / 100;
                        double LineLead = double.Parse(sTHB) * double.Parse(LineLeadInc) / 100;
                        double Super = double.Parse(sTHB) * double.Parse(SupInc) / 100;

                        dt.Rows.Add(eff.ToString(), empInc.ToString("0.00"), LineLead.ToString("0.00"), Super.ToString("0.00"));
                        // 
                    }
                }

                string ActualEff = setActualEff(ef, stepUpRate);

                //int xsx = 8;
                //if (NameDBtb == "cutting_inc_break_tb")
                //{
                //    xsx = 0;
                //    if (hr < 8) hr = 8;
                //}
                //if (hr >= xsx)
                //{

                for (int i = 1; i < 14; i++)
                {
                    // MessageBox.Show(ActualEff + "==" + dt.Rows[i - 1][0].ToString());
                    if (ActualEff == dt.Rows[i - 1][0].ToString())
                    {
                        //resultTurn = dt.Rows[i - 1][0].ToString(); 

                        resultTurn[0] = dt.Rows[i - 1][0].ToString();
                        resultTurn[1] = ((double.Parse(dt.Rows[i - 1][1].ToString()) / 8) * hr).ToString("#.##");
                        resultTurn[2] = ((double.Parse(dt.Rows[i - 1][2].ToString()) / 8) * hr).ToString("#.##");
                        resultTurn[3] = ((double.Parse(dt.Rows[i - 1][3].ToString()) / 8) * hr).ToString("#.##");
                        break;
                    }
                    else if (int.Parse(ActualEff) < int.Parse(dt.Rows[i - 1][0].ToString()))
                    {
                        resultTurn[0] = "";
                        resultTurn[1] = "";
                        resultTurn[2] = "";
                        resultTurn[3] = "";
                        break;
                    }
                    else if (int.Parse(ActualEff) > int.Parse(dt.Rows[dt.Rows.Count - 1][0].ToString()))
                    {
                        resultTurn[0] = dt.Rows[dt.Rows.Count - 1][0].ToString();
                        resultTurn[1] = ((double.Parse(dt.Rows[dt.Rows.Count - 1][1].ToString()) / 8) * hr).ToString("#.##");
                        resultTurn[2] = ((double.Parse(dt.Rows[dt.Rows.Count - 1][2].ToString()) / 8) * hr).ToString("#.##");
                        resultTurn[3] = ((double.Parse(dt.Rows[dt.Rows.Count - 1][3].ToString()) / 8) * hr).ToString("#.##");
                        break;
                    }
                    else
                    {
                        resultTurn[0] = "";
                        resultTurn[1] = "";
                        resultTurn[2] = "";
                        resultTurn[3] = "";
                    }
                }
                // }
            }
            else
            {
                resultTurn[0] = "DBF";
            }

            return resultTurn;
        }
    }
}
