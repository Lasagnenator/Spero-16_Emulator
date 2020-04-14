# -*- coding: utf-8 -*-

###########################################################################
## Python code generated with wxFormBuilder (version Oct 26 2018)
## http://www.wxformbuilder.org/
##
## PLEASE DO *NOT* EDIT THIS FILE!
###########################################################################

import wx
import wx.xrc

###########################################################################
## Class MainFrame
###########################################################################

class MainFrame ( wx.Frame ):

	def __init__( self, parent ):
		wx.Frame.__init__ ( self, parent, id = wx.ID_ANY, title = u"Assembler", pos = wx.DefaultPosition, size = wx.Size( -1,-1 ), style = wx.CAPTION|wx.CLOSE_BOX|wx.MINIMIZE_BOX|wx.SYSTEM_MENU|wx.TAB_TRAVERSAL )

		self.SetSizeHints( wx.DefaultSize, wx.DefaultSize )

		self.statusbar = self.CreateStatusBar( 1, wx.STB_DEFAULT_STYLE, wx.ID_ANY )
		bSizer7 = wx.BoxSizer( wx.VERTICAL )

		bSizer1 = wx.BoxSizer( wx.HORIZONTAL )

		bSizer4 = wx.BoxSizer( wx.VERTICAL )

		self.m_staticText3 = wx.StaticText( self, wx.ID_ANY, u"Input file", wx.DefaultPosition, wx.DefaultSize, 0 )
		self.m_staticText3.Wrap( -1 )

		bSizer4.Add( self.m_staticText3, 0, wx.ALL, 5 )

		self.m_staticText4 = wx.StaticText( self, wx.ID_ANY, u"Output file", wx.DefaultPosition, wx.DefaultSize, 0 )
		self.m_staticText4.Wrap( -1 )

		bSizer4.Add( self.m_staticText4, 0, wx.ALL, 5 )


		bSizer1.Add( bSizer4, 0, wx.ALIGN_CENTER_VERTICAL, 5 )

		bSizer6 = wx.BoxSizer( wx.VERTICAL )

		self.OpenFilePicker = wx.FilePickerCtrl( self, wx.ID_ANY, wx.EmptyString, u"Open assembly file", u"*.asm", wx.DefaultPosition, wx.DefaultSize, wx.FLP_CHANGE_DIR|wx.FLP_FILE_MUST_EXIST|wx.FLP_OPEN|wx.FLP_SMALL|wx.FLP_USE_TEXTCTRL )
		bSizer6.Add( self.OpenFilePicker, 0, wx.ALL|wx.EXPAND, 5 )

		self.SaveFilePicker = wx.FilePickerCtrl( self, wx.ID_ANY, wx.EmptyString, u"Save binary", u"*.r16.bin", wx.DefaultPosition, wx.DefaultSize, wx.FLP_CHANGE_DIR|wx.FLP_OVERWRITE_PROMPT|wx.FLP_SAVE|wx.FLP_SMALL|wx.FLP_USE_TEXTCTRL )
		bSizer6.Add( self.SaveFilePicker, 0, wx.ALL|wx.EXPAND, 5 )


		bSizer1.Add( bSizer6, 1, wx.EXPAND, 5 )


		bSizer7.Add( bSizer1, 1, wx.EXPAND, 5 )

		self.m_button1 = wx.Button( self, wx.ID_ANY, u"Start", wx.DefaultPosition, wx.DefaultSize, 0 )
		bSizer7.Add( self.m_button1, 0, wx.ALL|wx.ALIGN_CENTER_HORIZONTAL, 5 )


		self.SetSizer( bSizer7 )
		self.Layout()
		bSizer7.Fit( self )

		self.Centre( wx.BOTH )

		# Connect Events
		self.m_button1.Bind( wx.EVT_BUTTON, self.CreateASM )

	def __del__( self ):
		pass


	# Virtual event handlers, overide them in your derived class
	def CreateASM( self, event ):
		event.Skip()


