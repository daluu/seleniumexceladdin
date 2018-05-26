# Copyright (c) 2014 Takashi Yoshizawa
#
# this script is Python 2.7
#
# How to use:
#
# 1. Open the Command Prompt
# 2. Type "python automation-python.py"

import win32com.client
import os, sys
import logging

logger = logging.getLogger()
logger.level = logging.DEBUG
logger.addHandler(logging.StreamHandler(sys.stdout))

excel = win32com.client.Dispatch("Excel.Application")
excel.Visible = True

addin = excel.ComAddins("SeleniumExcelAddIn").Object
logger.info("SeleniumExcelAddIn version = %s" % addin.Version)


filename = os.path.join(os.getcwd(), "selenium-excel-addin-sample.xlsx")
logger.info(filename)

excel.Workbooks.Open(filename)

#addin.Execute('WebDriverChrome')
#addin.Execute('WebDriverInternetExplorer')
addin.Execute('WebDriverFirefox')
addin.Execute("Run")

excel.ActiveWorkbook.Save()
excel.Quit()
