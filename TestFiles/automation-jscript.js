// Copyright (c) 2014 Takashi Yoshizawa

/*
 * This is JavaScript(JScript) Langauge.
 *
 * How to use:
 *
 * 1. Open the Command Prompt
 * 2. Type "cscript automation-jscript.js"
 *
 */

var excel = new ActiveXObject('Excel.Application');
excel.Visible = true;

var addin = excel.ComAddins('SeleniumExcelAddin').Object
WScript.Echo('SeleniumExcelAddin version = ' + addin.Version);

var shell = new ActiveXObject('WScript.Shell');
var filename = shell.CurrentDirectory + '\\selenium-excel-addin-sample.xlsx';

excel.Workbooks.Open(filename);

addin.Execute('WebDriverInternetExplorer');
//addin.Execute('WebDriverFirefox');
//addin.Execute('WebDriverChrome');

// Test Run
addin.Execute('Run');

excel.ActiveWorkbook.Save();

excel.Quit();
