using System;
using System.Windows.Forms;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;
using System.Xml.Schema;
using System.Xml.Linq;
using System.IO;
using Formulário_Inicial.ServiceReference1;
using varLocal = Formulário_Inicial.ServiceReference2;

namespace Formulário_Inicial
{

    public partial class Form1 : Form

    {
 
        Excel.Workbook xlsWorkbook;
        Excel.Application xlsApp;
        Excel.Worksheet xlWorksheet;
        private String xmlSchema;
        private String ficheiroXml;
        XmlDocument doc;
        XmlDeclaration dec;
        XmlElement projeto;


        public Form1( )
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog excel = new OpenFileDialog();

            if (excel.ShowDialog() == DialogResult.OK)
            {
                FecharExcel();
                System.IO.StreamReader sr = new System.IO.StreamReader(excel.FileName);
                textBox1.Text = string.Format("{0}", excel.FileName);
                listBox1.Items.Add(Path.GetFileName(textBox1.Text));

                sr.Close();

            }

        }
        private void FecharExcel()
        {
            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
            foreach (System.Diagnostics.Process p in process)
            {
                if (!string.IsNullOrEmpty(p.ProcessName))
                {
                    try
                    {
                        p.Kill();
                    }
                    catch { }
                }
            }
        }


       
        private bool importarExcel1(string caminhoExcel,XmlDocument doc, XmlElement projeto)
        {
            try
            {
                XmlElement anos = doc.CreateElement("Anos");
                XmlNode caminhoAno;

                for (int i = 8; i <= 36; i++)
                {
                  XmlElement  camas = doc.CreateElement("Camas");
                  XmlElement  camasHosGer = doc.CreateElement("CamasHospitalGeral");
                  XmlElement  camasHosEsp = doc.CreateElement("CamasHospitalEspecializados");
                  XmlElement  camasCentroSaude = doc.CreateElement("CamasCentrodeSaude");
                 caminhoAno = doc.SelectSingleNode("/Projeto//Anos[@ano= " + 
                        xlWorksheet.Cells[i, 1].Value + " ] ");
                    //mudei aqui
                    if (caminhoAno != null)
                    {

                        if (Convert.ToString(xlWorksheet.Cells[i, 2].Value).Equals("0"))

                        {

                            camasHosGer.InnerText = "-";

                        }
                        else
                        {
                            camasHosGer.InnerText = Convert.ToString(xlWorksheet.Cells[i, 2].Value);
                        }


                        if (Convert.ToString(xlWorksheet.Cells[i, 4].Value).Equals("0"))
                        {
                            camasCentroSaude.InnerText = "-";
                        }
                        else
                        {
                            camasCentroSaude.InnerText = Convert.ToString(xlWorksheet.Cells[i, 4].Value);
                        }

                        projeto.AppendChild(anos);
                        camas.AppendChild(camasHosGer);
                        camas.AppendChild(camasHosEsp);
                        camas.AppendChild(camasCentroSaude);
                        caminhoAno.AppendChild(camas);

                    }
                    else
                    {
                     
                        anos = doc.CreateElement("Anos");
                        anos.SetAttribute("ano", Convert.ToString(xlWorksheet.Cells[i, 1].Value));
                        if (Convert.ToString(xlWorksheet.Cells[i, 2].Value).Equals("0"))

                        {

                            camasHosGer.InnerText = "-";

                        }
                        else
                        {
                            camasHosGer.InnerText = Convert.ToString(xlWorksheet.Cells[i, 2].Value);
                        }


                        if (Convert.ToString(xlWorksheet.Cells[i, 4].Value).Equals("0"))
                        {
                            camasCentroSaude.InnerText = "-";
                        }
                        else
                        {
                            camasCentroSaude.InnerText = Convert.ToString(xlWorksheet.Cells[i, 4].Value);
                        }

                        projeto.AppendChild(anos);
                        camas.AppendChild(camasHosGer);
                        camas.AppendChild(camasHosEsp);
                        camas.AppendChild(camasCentroSaude);
                        anos.AppendChild(camas);

                    }
                  
                }
                return true;
            }

            catch (Exception ex)
            {

                return false;
            }

        }





        private bool importarExcel2(string caminhoExcel2, XmlDocument doc, XmlElement projeto)
        {
            try
            {
                XmlElement anos = doc.CreateElement("Anos");
                XmlNode caminhoAno;
                for (int j = 9; j <= 33; j++)
                {
                    XmlElement registos = doc.CreateElement("Registos");
                    XmlElement consultas = doc.CreateElement("Consultas");
                    XmlElement internamentos = doc.CreateElement("Internamentos");
                    XmlElement urgencias = doc.CreateElement("Urgencias");
                    XmlElement totalC = doc.CreateElement("Total");
                    XmlElement totalI = doc.CreateElement("Total");
                    XmlElement totalU = doc.CreateElement("Total");
                    XmlElement hosC = doc.CreateElement("Hospitais");
                    XmlElement hosI = doc.CreateElement("Hospitais");
                    XmlElement hosU = doc.CreateElement("Hospitais");
                    XmlElement centrC = doc.CreateElement("CentrosSaude");
                    XmlElement centrI = doc.CreateElement("CentrosSaude");
                    XmlElement centrU = doc.CreateElement("CentrosSaude");

                    caminhoAno = doc.SelectSingleNode("/Projeto//Anos[@ano= " + xlWorksheet.Cells[j, 1].Value + " ] ");
                    //Mexi aqui (acrescentei os ifs para por os X)
                    if (caminhoAno != null)
                    {



                        if(Convert.ToString(xlWorksheet.Cells[j, 2].Value).Equals("0"))
                        {
                            totalC.InnerText = "X";
                        }
                        else
                        {
                            totalC.InnerText = Convert.ToString(xlWorksheet.Cells[j, 2].Value);
                        }

                        if(Convert.ToString(xlWorksheet.Cells[j, 3].Value).Equals("0"))
                        {
                            hosC.InnerText = "X";
                        }
                        else
                        {
                            hosC.InnerText = Convert.ToString(xlWorksheet.Cells[j, 3].Value);
                        }

                        if(Convert.ToString(xlWorksheet.Cells[j, 4].Value).Equals("0"))
                        {
                            centrC.InnerText = "X";
                        }
                        else
                        {
                            centrC.InnerText = Convert.ToString(xlWorksheet.Cells[j, 4].Value);
                        }
               
                        
                        consultas.AppendChild(totalC);
                        consultas.AppendChild(hosC);
                        consultas.AppendChild(centrC);
                        registos.AppendChild(consultas);
                        caminhoAno.AppendChild(registos);

                        //Mexi aqui (acrescentei os ifs para por os X)

                        if (Convert.ToString(xlWorksheet.Cells[j, 5].Value).Equals("0"))
                        {
                            totalI.InnerText = "X";
                        }
                        else
                        {
                            totalI.InnerText = Convert.ToString(xlWorksheet.Cells[j, 5].Value);
                        }


                        if(Convert.ToString(xlWorksheet.Cells[j, 6].Value).Equals("0"))
                        {
                            hosI.InnerText = "X";
                        }
                        else
                        {
                            hosI.InnerText = Convert.ToString(xlWorksheet.Cells[j, 6].Value);
                        }

                        if(Convert.ToString(xlWorksheet.Cells[j, 7].Value).Equals("0"))
                        {
                            centrI.InnerText = "X";
                        }
                        else
                        {
                            centrI.InnerText = Convert.ToString(xlWorksheet.Cells[j, 7].Value);
                        }
                        
                        
                        internamentos.AppendChild(totalI);
                        internamentos.AppendChild(hosI);
                        internamentos.AppendChild(centrI);
                        registos.AppendChild(internamentos);
                        caminhoAno.AppendChild(registos);


                        //Mexi aqui (acrescentei os ifs para por os X)
                        if (Convert.ToString(xlWorksheet.Cells[j, 8].Value).Equals("0"))
                        {
                            totalU.InnerText = "X";
                        }
                        else
                        {
                            totalU.InnerText = Convert.ToString(xlWorksheet.Cells[j, 8].Value);
                        }

                        if(Convert.ToString(xlWorksheet.Cells[j, 9].Value).Equals("0"))
                        {
                            hosU.InnerText = "X";
                        }
                        else
                        {
                            hosU.InnerText = Convert.ToString(xlWorksheet.Cells[j, 9].Value);
                        }
                        
                        if(Convert.ToString(xlWorksheet.Cells[j, 10].Value).Equals("0"))
                        {
                            centrU.InnerText = "X";
                        }
                        else
                        {
                            centrU.InnerText = Convert.ToString(xlWorksheet.Cells[j, 10].Value);
                        }
                        
                        urgencias.AppendChild(totalU);
                        urgencias.AppendChild(hosU);
                        urgencias.AppendChild(centrU);
                        registos.AppendChild(urgencias);
                        caminhoAno.AppendChild(registos);
                    }

                    else
                    {
                        anos = doc.CreateElement("Anos");
                        anos.SetAttribute("ano", Convert.ToString(xlWorksheet.Cells[j, 1].Value));

                        //Mexi aqui (acrescentei os ifs para por os X)
                        if (Convert.ToString(xlWorksheet.Cells[j, 2].Value).Equals("0"))
                        {
                            totalC.InnerText = "X";
                        }
                        else
                        {
                            totalC.InnerText = Convert.ToString(xlWorksheet.Cells[j, 2].Value);
                        }

                        if(Convert.ToString(xlWorksheet.Cells[j, 3].Value).Equals("0"))
                        {
                            hosC.InnerText = "X";
                        }
                        else
                        {
                            hosC.InnerText = Convert.ToString(xlWorksheet.Cells[j, 3].Value);
                        }
                        
                        if(Convert.ToString(xlWorksheet.Cells[j, 4].Value).Equals("0"))
                        {
                            centrC.InnerText = "X";
                        }
                        else
                        {
                            centrC.InnerText = Convert.ToString(xlWorksheet.Cells[j, 4].Value);
                        }
                        
                        consultas.AppendChild(totalC);
                        consultas.AppendChild(hosC);
                        consultas.AppendChild(centrC);
                        anos.AppendChild(consultas);

                        //Mexi aqui (acrescentei os ifs para por os X)
                        if (Convert.ToString(xlWorksheet.Cells[j, 5].Value).Equals("0"))
                        {
                            totalI.InnerText = "X";
                        }
                        else
                        {
                            totalI.InnerText = Convert.ToString(xlWorksheet.Cells[j, 5].Value);
                        }

                        if(Convert.ToString(xlWorksheet.Cells[j, 6].Value).Equals("0"))
                        {
                            hosI.InnerText = "X";
                        }
                        else
                        {
                            hosI.InnerText = Convert.ToString(xlWorksheet.Cells[j, 6].Value);
                        }
                        
                        if(Convert.ToString(xlWorksheet.Cells[j, 7].Value).Equals("0"))
                        {
                            centrI.InnerText = "X";
                        }
                        else
                        {
                            centrI.InnerText = Convert.ToString(xlWorksheet.Cells[j, 7].Value);
                        }
                        
                        
                        internamentos.AppendChild(totalI);
                        internamentos.AppendChild(hosI);
                        internamentos.AppendChild(centrI);
                        anos.AppendChild(internamentos);

                        //Mexi aqui (acrescentei os ifs para por os X)
                        if (Convert.ToString(xlWorksheet.Cells[j, 8].Value).Equals("0"))
                        {
                            totalU.InnerText = "X";
                        }
                        else
                        {
                            totalU.InnerText = Convert.ToString(xlWorksheet.Cells[j, 8].Value);
                        }
                        
                        
                        if(Convert.ToString(xlWorksheet.Cells[j, 9].Value).Equals("0"))
                        {
                            hosU.InnerText = "X";
                        }
                        else
                        {
                            hosU.InnerText = Convert.ToString(xlWorksheet.Cells[j, 9].Value);
                        }


                        if(Convert.ToString(xlWorksheet.Cells[j, 10].Value).Equals("0"))
                        {
                            centrU.InnerText = "X";
                        }
                        else
                        {
                            centrU.InnerText = Convert.ToString(xlWorksheet.Cells[j, 10].Value);
                        }
                        
                        
                        urgencias.AppendChild(totalU);
                        urgencias.AppendChild(hosU);
                        urgencias.AppendChild(centrU);
                        anos.AppendChild(urgencias);
                        projeto.AppendChild(anos);

                    }
                }
                    return true;
                }
            

            catch (Exception ex)
            {

                return false;
            }
        }



        private bool importarExcel3(string caminhoExcel3, XmlDocument doc, XmlElement projeto)
        {

            try
            {
                XmlElement anos = doc.CreateElement("Anos");
                XmlNode caminhoAno;




                for (int j = 9; j <= 33; j++)
                {

                    XmlElement estabelecimentosSaude = doc.CreateElement("EstabelecimentosSaude");
                    XmlElement hospGeral = doc.CreateElement("HospitaisGerais");
                    XmlElement hosEspe = doc.CreateElement("HospitaisEspecialiazados");
                    XmlElement centroSaude = doc.CreateElement("CentrosDeSaude");
                    XmlElement extCentroSaude = doc.CreateElement("ExtensoesCentroSaude");
                    caminhoAno = doc.SelectSingleNode("/Projeto//Anos[@ano = " + xlWorksheet.Cells[j, 1].Value + " ] ");

                    if (caminhoAno != null)
                    {
                        //Mexi aqui (acrescentei os ifs para por os X)

                        if (Convert.ToString(xlWorksheet.Cells[j, 2].Value).Equals("0"))
                        {
                            hospGeral.InnerText = "X";
                        }
                        
                        else
                        {
                            hospGeral.InnerText = Convert.ToString(xlWorksheet.Cells[j, 2].Value);
                        }

                        
                        if(Convert.ToString(xlWorksheet.Cells[j, 3].Value).Equals("0"))
                        {
                            hosEspe.InnerText = "X";
                        }
                       
                        else
                        {
                            hosEspe.InnerText = Convert.ToString(xlWorksheet.Cells[j, 3].Value);
                        }
                        
                        if(Convert.ToString(xlWorksheet.Cells[j, 4].Value).Equals("0"))
                        {
                            centroSaude.InnerText = "X";
                        }
                     
                        else
                        {
                            centroSaude.InnerText = Convert.ToString(xlWorksheet.Cells[j, 4].Value);
                        }


                        if(Convert.ToString(xlWorksheet.Cells[j, 5].Value).Equals("0"))
                        {
                            extCentroSaude.InnerText = "X";
                        }
                      
                        else
                        {
                            extCentroSaude.InnerText = Convert.ToString(xlWorksheet.Cells[j, 5].Value);
                        }
                        
                        
                        estabelecimentosSaude.AppendChild(hospGeral);
                        estabelecimentosSaude.AppendChild(hosEspe);
                        estabelecimentosSaude.AppendChild(centroSaude);
                        estabelecimentosSaude.AppendChild(extCentroSaude);

                        caminhoAno.AppendChild(estabelecimentosSaude);


                    }
                    else
                    {
                        anos = doc.CreateElement("Anos");
                        anos.SetAttribute("ano", Convert.ToString(xlWorksheet.Cells[j, 1].Value));

                        //Mexi aqui (acrescentei os ifs para por os X)
                        if (Convert.ToString(xlWorksheet.Cells[j, 2].Value).Equals("0"))
                        {
                            hospGeral.InnerText = "X";
                        }
                       
                        else
                        {
                            hospGeral.InnerText = Convert.ToString(xlWorksheet.Cells[j, 2].Value);
                        }


                        if(Convert.ToString(xlWorksheet.Cells[j, 3].Value).Equals("0"))
                        {
                            hosEspe.InnerText = "X";
                        }
                       
                        else
                        {
                            hosEspe.InnerText = Convert.ToString(xlWorksheet.Cells[j, 3].Value);
                        }
                        
                        if(Convert.ToString(xlWorksheet.Cells[j, 4].Value).Equals("0"))
                        {
                            centroSaude.InnerText = "X";
                        }
                       
                        else
                        {
                            centroSaude.InnerText = Convert.ToString(xlWorksheet.Cells[j, 4].Value);
                        }


                        if(Convert.ToString(xlWorksheet.Cells[j, 5].Value).Equals("0"))
                        {
                            extCentroSaude.InnerText = "X";
                        }
                       
                        else
                        {
                            extCentroSaude.InnerText = Convert.ToString(xlWorksheet.Cells[j, 5].Value);
                        }
                        
                        
                        estabelecimentosSaude.AppendChild(hospGeral);
                        estabelecimentosSaude.AppendChild(hosEspe);
                        estabelecimentosSaude.AppendChild(centroSaude);
                        estabelecimentosSaude.AppendChild(extCentroSaude);
                        anos.AppendChild(estabelecimentosSaude);
                        projeto.AppendChild(anos);
                    }




                }

                return true;
            }

            catch (Exception ex)
            {

                return false;
            }
        }




        private bool importarExcel4(string caminhoExcel4, XmlDocument doc, XmlElement projeto)
        {

            try
            {
                XmlElement anos = doc.CreateElement("Anos");
                XmlNode caminhoAno;


                for (int j = 9; j <= 33; j++)
                {

                    XmlElement lotacao = doc.CreateElement("Lotacao");
                    XmlElement hospGerais = doc.CreateElement("HospitaisGerais");
                    XmlElement hosEspec = doc.CreateElement("HospitaisEspecialiazados");
                    XmlElement extCentrosSaude = doc.CreateElement("ExtensoesCentroSaude");
                    caminhoAno = doc.SelectSingleNode("/Projeto//Anos[@ano = " + xlWorksheet.Cells[j, 1].Value + " ] ");

                    if (caminhoAno != null)
                    {

                        //Mexi aqui (acrescentei os ifs para por os X)
                        if (Convert.ToString(xlWorksheet.Cells[j, 2].Value).Equals("0"))
                        {
                            hospGerais.InnerText = "X";
                        }
                        else
                        {
                            hospGerais.InnerText = Convert.ToString(xlWorksheet.Cells[j, 2].Value);
                        }

                        if(Convert.ToString(xlWorksheet.Cells[j, 3].Value).Equals("0"))
                        {
                            hosEspec.InnerText = "X";
                        }
                        else
                        {
                            hosEspec.InnerText = Convert.ToString(xlWorksheet.Cells[j, 3].Value);
                        }
                        
                        if(Convert.ToString(xlWorksheet.Cells[j, 4].Value).Equals("0"))
                        {
                            extCentrosSaude.InnerText = "X";
                        }
                        else
                        {
                            extCentrosSaude.InnerText = Convert.ToString(xlWorksheet.Cells[j, 4].Value);
                        }
                        
                        lotacao.AppendChild(hospGerais);
                        lotacao.AppendChild(hosEspec);
                        lotacao.AppendChild(extCentrosSaude);

                        caminhoAno.AppendChild(lotacao);


                    }
                    else
                    {
                        anos = doc.CreateElement("Anos");
                        anos.SetAttribute("ano", Convert.ToString(xlWorksheet.Cells[j, 1].Value));


                        //Mexi aqui (acrescentei os ifs para por os X)
                        if (Convert.ToString(xlWorksheet.Cells[j, 2].Value).Equals("0"))
                        {
                            hospGerais.InnerText = "X";
                        }
                        else
                        {
                            hospGerais.InnerText = Convert.ToString(xlWorksheet.Cells[j, 2].Value);
                        }


                        if(Convert.ToString(xlWorksheet.Cells[j, 3].Value).Equals("0"))
                        {
                            hosEspec.InnerText = "X";
                        }
                        else
                        {
                            hosEspec.InnerText = Convert.ToString(xlWorksheet.Cells[j, 3].Value);
                        }
                        
                        if(Convert.ToString(xlWorksheet.Cells[j, 4].Value).Equals("0"))
                        {
                            extCentrosSaude.InnerText = "X";
                        }
                        else
                        {
                            extCentrosSaude.InnerText = Convert.ToString(xlWorksheet.Cells[j, 4].Value);
                        }
                        
                        lotacao.AppendChild(hospGerais);
                        lotacao.AppendChild(hosEspec);
                        lotacao.AppendChild(extCentrosSaude);
                        anos.AppendChild(lotacao);
                        projeto.AppendChild(anos);
                    }
                }
                    return true;
                }

            catch (Exception ex)
            {

                return false;
            }

        }




        private bool importarExcel5(string caminhoExcel5,XmlDocument doc, XmlElement projeto)
        {
            try
            {
                XmlElement anos = doc.CreateElement("Anos");
                XmlNode caminhoAno;


                for (int j = 9; j <= 42; j++)
                {

                    XmlElement despesaSns = doc.CreateElement("DespesaSns");
                    XmlElement total = doc.CreateElement("Total");
                    XmlElement cPessoal = doc.CreateElement("ComPessoal");


                    caminhoAno = doc.SelectSingleNode("/Projeto//Anos[@ano = " + xlWorksheet.Cells[j, 1].Value + " ] ");

                    if (caminhoAno != null)
                    {

                        //Mexi aqui (acrescentei os ifs para por os X)
                        if (Convert.ToString(xlWorksheet.Cells[j, 2].Value).Equals("0"))
                        {
                            total.InnerText = "X";
                        }
                        else
                        {
                            total.InnerText = Convert.ToString(xlWorksheet.Cells[j, 2].Value);
                        }

                        
                        if(Convert.ToString(xlWorksheet.Cells[j, 3].Value).Equals("0"))
                        {
                            cPessoal.InnerText = "X";
                        }
                        else
                        {
                            cPessoal.InnerText = Convert.ToString(xlWorksheet.Cells[j, 3].Value);
                        }
                        

                        despesaSns.AppendChild(total);
                        despesaSns.AppendChild(cPessoal);

                        caminhoAno.AppendChild(despesaSns);


                    }
                    else
                    {
                        anos = doc.CreateElement("Anos");
                        anos.SetAttribute("ano", Convert.ToString(xlWorksheet.Cells[j, 1].Value));


                        //Mexi aqui (acrescentei os ifs para por os X)
                        if (Convert.ToString(xlWorksheet.Cells[j, 2].Value).Equals("0"))
                        {
                            total.InnerText = "X";
                        }
                        else
                        {
                            total.InnerText = Convert.ToString(xlWorksheet.Cells[j, 2].Value);
                        }


                        if(Convert.ToString(xlWorksheet.Cells[j, 3].Value).Equals("0"))
                        {
                            cPessoal.InnerText = "X";
                        }
                        else
                        {
                            cPessoal.InnerText = Convert.ToString(xlWorksheet.Cells[j, 3].Value);
                        }
                        
                        

                        despesaSns.AppendChild(total);
                        despesaSns.AppendChild(cPessoal);
                        anos.AppendChild(despesaSns);
                        projeto.AppendChild(anos);
                    }

                }
                 return true;
            }

            catch (Exception ex)
            {

                return false;
            }
        }



        private bool importarExcel6(string caminhoExcel6, XmlDocument doc, XmlElement projeto)
        {
            try
            {
                XmlElement anos = doc.CreateElement("Anos");
                XmlNode caminhoAno;


                for (int j = 8; j <= 39; j++)
                {

                    XmlElement despesaSnsPorHab = doc.CreateElement("DespesaSnsPorHab");


                    caminhoAno = doc.SelectSingleNode("/Projeto//Anos[@ano = " + xlWorksheet.Cells[j, 1].Value + " ] ");

                    if (caminhoAno != null)
                    {

                        //Mexi aqui (acrescentei os ifs para por os X)
                        if (Convert.ToString(xlWorksheet.Cells[j, 2].Value).Equals("0"))
                        {
                            despesaSnsPorHab.InnerText = "X";
                        }
                        else
                        {
                            despesaSnsPorHab.InnerText = Convert.ToString(xlWorksheet.Cells[j, 2].Value);
                        }

                        



                        caminhoAno.AppendChild(despesaSnsPorHab);


                    }
                    else
                    {
                        anos = doc.CreateElement("Anos");
                        anos.SetAttribute("ano", Convert.ToString(xlWorksheet.Cells[j, 1].Value));


                        //Mexi aqui (acrescentei os ifs para por os X)
                        if (Convert.ToString(xlWorksheet.Cells[j, 2].Value).Equals("0"))
                        {
                            despesaSnsPorHab.InnerText = "X";
                        }
                        else
                        {
                            despesaSnsPorHab.InnerText = Convert.ToString(xlWorksheet.Cells[j, 2].Value);
                        }

                        



                        anos.AppendChild(despesaSnsPorHab);
                        projeto.AppendChild(anos);
                    }

                }

                return true;
            }

            catch (Exception ex)
            {

                return false;
            }
        }



        private bool importarExcel7(string caminhoExcel7, XmlDocument doc, XmlElement projeto)
        {
            try
            {

                XmlElement anos = doc.CreateElement("Anos");
                XmlNode caminhoAno;

                for (int j = 9; j <= 32; j++)
                {

                    XmlElement encargosComMedicamentos = doc.CreateElement("EncargosComMedicamentos");
                    XmlElement sns = doc.CreateElement("DoSns");
                    XmlElement utente = doc.CreateElement("DoUtente");


                    caminhoAno = doc.SelectSingleNode("/Projeto//Anos[@ano = " + xlWorksheet.Cells[j, 1].Value + " ] ");

                    if (caminhoAno != null)
                    {

                        //Mexi aqui (acrescentei os ifs para por os X)
                        if (Convert.ToString(xlWorksheet.Cells[j, 2].Value).Equals("0"))
                        {
                            sns.InnerText = "X";
                        }
                        else
                        {
                            sns.InnerText = Convert.ToString(xlWorksheet.Cells[j, 2].Value);
                        }


                        if(Convert.ToString(xlWorksheet.Cells[j, 3].Value).Equals("0"))
                        {
                            utente.InnerText = "X";
                        }
                        else
                        {
                            utente.InnerText = Convert.ToString(xlWorksheet.Cells[j, 3].Value);
                        }

                        
                        

                        encargosComMedicamentos.AppendChild(sns);
                        encargosComMedicamentos.AppendChild(utente);

                        caminhoAno.AppendChild(encargosComMedicamentos);


                    }
                    else
                    {
                        anos = doc.CreateElement("Anos");
                        anos.SetAttribute("ano", Convert.ToString(xlWorksheet.Cells[j, 1].Value));


                        //Mexi aqui (acrescentei os ifs para por os X)
                        if (Convert.ToString(xlWorksheet.Cells[j, 2].Value).Equals("0"))
                        {
                            sns.InnerText = "X";
                        }
                        else
                        {
                            sns.InnerText = Convert.ToString(xlWorksheet.Cells[j, 2].Value);
                        }


                        if(Convert.ToString(xlWorksheet.Cells[j, 3].Value).Equals("0"))
                        {
                            utente.InnerText = "X";
                        }
                        else
                        {
                            utente.InnerText = Convert.ToString(xlWorksheet.Cells[j, 3].Value);
                        }
                        
                        

                        encargosComMedicamentos.AppendChild(sns);
                        encargosComMedicamentos.AppendChild(utente);
                        anos.AppendChild(encargosComMedicamentos);
                        projeto.AppendChild(anos);
                    }

                }

                return true;
            }

            catch (Exception ex)
            {

                return false;
            }

        }


        private bool importarExcel8(string caminhoExcel8, XmlDocument doc, XmlElement projeto)
        {
            try
            {
                XmlElement anos = doc.CreateElement("Anos");
                XmlNode caminhoAno;


                for (int j = 8; j <= 31; j++)
                {


                    XmlElement pessoalAoServico = doc.CreateElement("PessoalAoServico");
                    XmlElement medicos = doc.CreateElement("Medicos");
                    XmlElement pessoalEnfermagem = doc.CreateElement("PessoalDeEnfermagem");
                    XmlElement enfermeiros = doc.CreateElement("Enfermeiros");
                    XmlElement tecnicosDiagTerap = doc.CreateElement("TecnicosDiagnosticoTerapeutica");


                    caminhoAno = doc.SelectSingleNode("/Projeto//Anos[@ano = " + xlWorksheet.Cells[j, 1].Value + " ] ");

                    if (caminhoAno != null)
                    {

                        //Mexi aqui (acrescentei os ifs para por os X)
                        if (Convert.ToString(xlWorksheet.Cells[j, 2].Value).Equals("0"))
                        {
                            medicos.InnerText = "X";
                        }
                        else
                        {
                            medicos.InnerText = Convert.ToString(xlWorksheet.Cells[j, 2].Value);
                        }

                        if(Convert.ToString(xlWorksheet.Cells[j, 3].Value).Equals("0"))
                        {
                            pessoalEnfermagem.InnerText = "X";
                        }
                        else
                        {
                            pessoalEnfermagem.InnerText = Convert.ToString(xlWorksheet.Cells[j, 3].Value);
                        }



                        if(Convert.ToString(xlWorksheet.Cells[j, 4].Value).Equals("0"))
                        {
                            enfermeiros.InnerText = "X";
                        }
                        else
                        {
                            enfermeiros.InnerText = Convert.ToString(xlWorksheet.Cells[j, 4].Value);
                        }


                        if(Convert.ToString(xlWorksheet.Cells[j, 5].Value).Equals("0"))
                        {
                            tecnicosDiagTerap.InnerText = "X";
                        }
                        else
                        {
                            tecnicosDiagTerap.InnerText = Convert.ToString(xlWorksheet.Cells[j, 5].Value);
                        }


                        pessoalAoServico.AppendChild(medicos);
                        pessoalAoServico.AppendChild(pessoalEnfermagem);
                        pessoalAoServico.AppendChild(enfermeiros);
                        pessoalAoServico.AppendChild(tecnicosDiagTerap);

                        caminhoAno.AppendChild(pessoalAoServico);


                    }
                    else
                    {
                        anos = doc.CreateElement("Anos");
                        anos.SetAttribute("ano", Convert.ToString(xlWorksheet.Cells[j, 1].Value));


                        //Mexi aqui (acrescentei os ifs para por os X)
                        if (Convert.ToString(xlWorksheet.Cells[j, 2].Value).Equals("0"))
                        {
                            medicos.InnerText = "X";
                        }
                        else
                        {
                            medicos.InnerText = Convert.ToString(xlWorksheet.Cells[j, 2].Value);
                        }

                        if(Convert.ToString(xlWorksheet.Cells[j, 3].Value).Euqals("0"))
                        {
                            pessoalEnfermagem.InnerText = "X";
                        }
                        else
                        {
                            pessoalEnfermagem.InnerText = Convert.ToString(xlWorksheet.Cells[j, 3].Value);
                        }


                        if(Convert.ToString(xlWorksheet.Cells[j, 4].Value).Equals("0"))
                        {
                            enfermeiros.InnerText = "X";
                        }
                        else
                        {
                            enfermeiros.InnerText = Convert.ToString(xlWorksheet.Cells[j, 4].Value);
                        }


                        if(Convert.ToString(xlWorksheet.Cells[j, 5].Value).Equals("0"))
                        {
                            tecnicosDiagTerap.InnerText = "X";
                        }
                        else
                        {
                            tecnicosDiagTerap.InnerText = Convert.ToString(xlWorksheet.Cells[j, 5].Value);
                        }


                        pessoalAoServico.AppendChild(medicos);
                        pessoalAoServico.AppendChild(pessoalEnfermagem);
                        pessoalAoServico.AppendChild(enfermeiros);
                        pessoalAoServico.AppendChild(tecnicosDiagTerap);
                        anos.AppendChild(pessoalAoServico);
                        projeto.AppendChild(anos);
                    }


                }
                return true;
            }

            catch (Exception ex)
            {

                return false;
            }

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            FecharExcel();

            string output = null;
            if (doc == null)
            {
                doc = new XmlDocument();

                dec = doc.CreateXmlDeclaration("1.0", null, null);
                doc.AppendChild(dec);

                projeto = doc.CreateElement("Projeto");
                doc.AppendChild(projeto);
                
            }
            //mudei aqui
            //tirei um else que nao era preciso
            xlsApp = new Excel.Application();
            xlsApp.Visible = false;
            //fiz esta proteção por causa da text box se estiver vazia
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                xlsWorkbook = xlsApp.Workbooks.Open(textBox1.Text, Type.Missing, true);
                xlWorksheet = (Excel.Worksheet)xlsWorkbook.Worksheets.get_Item(1);
                if (Convert.ToString(xlWorksheet.Cells[4, 2].Value).Equals("SNS: camas nos estabelecimentos de saúde por 100 mil habitantes - Continente"))
                {
                    importarExcel1(textBox1.Text, doc, projeto);
                }
                else if (Convert.ToString(xlWorksheet.Cells[4, 2].Value).Equals("SNS: consultas, internamentos e urgências - Continente"))
                {
                    importarExcel2(textBox1.Text, doc, projeto);
                }
                else if (Convert.ToString(xlWorksheet.Cells[4, 2].Value).Equals("SNS: estabelecimentos de saúde - Continente"))
                {
                    importarExcel3(textBox1.Text, doc, projeto);
                }
                else if (Convert.ToString(xlWorksheet.Cells[4, 2].Value).Equals("SNS: lotação dos estabelecimentos de saúde - Continente"))
                {
                    importarExcel4(textBox1.Text, doc, projeto);
                }
                else if (Convert.ToString(xlWorksheet.Cells[4, 2].Value).Equals("SNS: despesa total e com pessoal ao serviço - Continente"))
                {
                    importarExcel5(textBox1.Text, doc, projeto);
                }
                else if (Convert.ToString(xlWorksheet.Cells[4, 2].Value).Equals("SNS: despesa total per capita - Continente"))
                {
                    importarExcel6(textBox1.Text, doc, projeto);
                }
                else if (Convert.ToString(xlWorksheet.Cells[4, 2].Value).Equals("SNS: encargos com medicamentos - Continente"))
                {
                    importarExcel7(textBox1.Text, doc, projeto);
                }
                else if (Convert.ToString(xlWorksheet.Cells[4, 2].Value).Equals("SNS: pessoal ao serviço - Continente"))
                {
                    importarExcel8(textBox1.Text, doc, projeto);
                }
                else
                {
                    MessageBox.Show("Não existe Excel!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }

                output = doc.OuterXml;
                doc.Save(@"example.xml");
                MessageBox.Show("XML Feito com sucesso!");
                xlsWorkbook.Close(0);
                xlsApp.Quit();

                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlsApp);
                xlsApp = null;
                FecharExcel();


                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Ficheiro Xml | *.xml";
                save.Title = "Guardar Xml";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (Stream s = File.Open(save.FileName, FileMode.CreateNew))
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.Write(output);

                 
                    }
                }

                Validator(output);
                Service1Client ser = new Service1Client();
                ser.ReceberXml(output);

                
            }
            else
            {
                MessageBox.Show("Introduza um Excel!","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


    //        this.Close();


        }


        private void Validator(string output)
        {

            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Introduza um schema para validar");
            }
            else
            {
                
                ficheiroXml = output;
                xmlSchema = textBox2.Text;

                XmlSchemaSet schemas = new XmlSchemaSet();
                schemas.Add(ficheiroXml, xmlSchema);

                Console.WriteLine("Attempting to validate");

                
                XDocument custOrdDoc = XDocument.Parse(ficheiroXml);
                 
                bool errors = false;

                try
                {
                    custOrdDoc.Validate(schemas, null);
                    MessageBox.Show("XML validado com sucesso");

                }
                catch (XmlSchemaValidationException e)
                {
                    Console.WriteLine(e.Message);
                    errors = true;
                }

                Console.WriteLine("Result: The XML file " + (errors ? "did not validate" : "validated"));

                Console.ReadLine();
            }
          
        }




        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog schema = new OpenFileDialog();

            if (schema.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(schema.FileName);
                textBox2.Text = string.Format("{0}", schema.FileName);
                sr.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void buttonWebService_Click(object sender, EventArgs e)
        {
            OpenFileDialog xml = new OpenFileDialog();

            if (xml.ShowDialog() == DialogResult.OK)
            {
               // XmlDocument xmlDoc = new XmlDocument();
               // xmlDoc.Load(xml.FileName);
               Service1Client serv= new Service1Client();


                var x = XDocument.Load(xml.FileName);
                string s = x.ToString();


                Validator(s);
                bool a =  serv.ReceberXml(s);
                if (a == true)
                {
                    MessageBox.Show("Enviado com sucesso para o servidor");
                }
                else
                {
                    MessageBox.Show("Erro");
                }
          

            }
        }
    }


}
