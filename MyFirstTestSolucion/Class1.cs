using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstTestSolucion
{
    [TestClass] // para que sepa q es proyecto de test el compilador
    // ctrl punto se reconoce bvisua 
    public class Class1
    {
        // framework base: c#
        // el framework q nos ayudafr a interactuar con la aplicacion : ui framework : selelinum webdriver
        // unit framewwork : MSTest 
        //(buscar e instlar selenium y mstest  y ver en referencias)
        // selelnium es un framwerok par amobile(apium) ,protector  y web 
        // acceso de comunicacion a los borwsersme permite el selelium webdriver se comunica y da funcionalidad
        //primero con web 
        //para eso necesitamos un objeto webdriver

        //Webdriver (hacer clik ora garega un using)
        IWebDriver webDriver;
        IWebDriver webDriverFirefox;
        public Class1()
        {
            //--webDriver = new ChromeDriver(@"C:\Users\Anghela\Documents\Seleniumwebdriver");
            webDriverFirefox = new FirefoxDriver(@"C:\Users\Anghela\Documents\SeleniumGekoDriver");

        }


        //crear una funcion retorna algo 
        public int calculatedSum(int a , int b)
        {
            return a + b;
            
        }

        // crea un metodo no devuelve mnada
        [TestMethod] // decorador ppara decir que este metodo corre el test
        public void MyFirstTest()
        {
            //navigate to automationpractice
            // vamos a abrir el browser e ir a nuestra pagina que queremos automatizar 
            //--webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=contact");

            webDriverFirefox.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=contact");

            //contact-link
            //-- IWebElement contactUsButton = webDriver.FindElement(By.Id("contact-link"));
            IWebElement contactUsButton = webDriverFirefox.FindElement(By.Id("contact-link"));
            contactUsButton.Click();


            //id_contact
            //--IWebElement subjectHeading = webDriver.FindElement(By.Id("id_contact"));
            IWebElement subjectHeading = webDriverFirefox.FindElement(By.Id("id_contact"));

            //creamos un objeto para agarrar los combo box 
            //nombre de la clase que me permite interactuar con el comobbox
            // para q reconozca debemos descargar selenium support y ctrl punto using 
            //calse q permite interactuar con el comob obx pq es caso especial 

            //subject heading combobox clase auxiliar que m e permite interactuar 
            //subjectheading es el control y le damos 
            SelectElement subjectHeadingCombobox = new SelectElement(subjectHeading);

            //como  seleccionar un option en combobox ?
            //caso especial no como el mismo botom 

            //Customer service
            // por el texto y no usamos por indice el control 
            subjectHeadingCombobox.SelectByText("Customer service");


            //mailadress  usaeremos name  "from "

            //capture email address input
            //--IWebElement emailAddress = webDriver.FindElement(By.Name("from"));
            IWebElement emailAddress = webDriverFirefox.FindElement(By.Name("from"));

            // comando para escribir sendkeys

            emailAddress.SendKeys("anghie_a@hotmail.com");

            // ordern reference text name

            // id_order
            //--IWebElement orderReferenceInput = webDriver.FindElement(By.Name("id_order"));
            IWebElement orderReferenceInput = webDriverFirefox.FindElement(By.Name("id_order"));
            orderReferenceInput.SendKeys("1234");


            // archivo C:\Users\Anghela\Documents

            //fileUpload
            //--IWebElement attchFile = webDriver.FindElement(By.Id("fileUpload"));
            IWebElement attachFile = webDriverFirefox.FindElement(By.Id("fileUpload"));
            attachFile.SendKeys(@"C:\Users\Anghela\Documents\archivoAutomation.txt");


            //id = message 
            //Mensaje

            //--IWebElement messageInput = webDriver.FindElement(By.Id("message"));
            IWebElement messageInput = webDriverFirefox.FindElement(By.Id("message"));
            messageInput.SendKeys("Test messages :) ");


            //submitMessage 
            //--IWebElement sendButton = webDriver.FindElement(By.Id("submitMessage"));
            IWebElement sendButton = webDriverFirefox.FindElement(By.Id("submitMessage"));
            sendButton.Click();

            // verificando el test
            // si el emensaje verde debe aparecer ese menasaje para saber q evidenemnte se ha mandao la informacion


            // usaremos xpath con criterios especiales 
            //"Your message has been successfully sent to our team."

            //TipoTag[@NombreProiedad='Identificador']/tipoTag[@NombrePropiedad= 'Identificador']..
            //input

            //xpath emailadress
            //id_email
            //input[@id='email']
            // noes reocoemndado por temas de mmemoria y carga mas 
            // si no hay lista de prioridades tb se peude usar xpath
            //* agarra a todos no es eficiente la especifica la busqeda es mas pequeña
            //input[@type='text']
            //para el texto
            //p[@class='alert alert-success']

            //-- IWebElement confirmationLabel = webDriver.FindElement(By.XPath("//p[@class='alert alert-success']"));
            IWebElement confirmationLabel = webDriverFirefox.FindElement(By.XPath("//p[@class='alert alert-success']"));
            string actualMessage = confirmationLabel.Text; // systema data
            string expectedMessage = "Your message has been successfully sent to our team.";

            // PUNTO DE INTERRUPCION VA A PARAR SI RELAMENTE EL CONTROL ME ESTA DANDO EL TEXTO 
            // SI ME DEVUELVE O NO O ETSA VACIO

            // F10 PASO ALA SGTE LINEA
            // asset confirma si un test a pasado o no  y la librearia Mstext es ese
            Assert.AreEqual(expectedMessage,actualMessage);
        }
    }
}