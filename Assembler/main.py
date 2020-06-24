import wx
import Frames
import assembler
import sys
import os

class MainFrameClass(Frames.MainFrame):
    def __init__(self, parent):
        Frames.MainFrame.__init__(self, parent)

    def CreateASM(self, event):
        os.system("cls")
        self.statusbar.SetStatusText("Started")
        file_path = self.OpenFilePicker.GetPath()
        try:
            asm = assembler.make_asm(file_path)
        except: #errors not handled by the assembler
            message = str(sys.exc_info()[1])
            wx.MessageDialog(self, message, caption="Error!",
                             style=wx.OK|wx.ICON_ERROR).ShowModal()
            self.statusbar.SetStatusText("Failure")
            print("Failure")
            return

        if assembler.failure:
            self.statusbar.SetStatusText("Failure")
            print("Failure")
            return

        try:
            out_file = self.SaveFilePicker.GetPath()
            with open(out_file, "w+") as file:
                file.write(asm)
            self.statusbar.SetStatusText("Success")
            print("Success")
        except:
            message = str(sys.exc_info()[1])
            wx.MessageDialog(self, message, caption="Error!",
                             style=wx.OK|wx.ICON_ERROR).ShowModal()
            self.statusbar.SetStatusText("Failure")
            print("Failure")
            return


App = wx.App()
MainFrame = MainFrameClass(None)
MainFrame.Show(True)
App.MainLoop()
