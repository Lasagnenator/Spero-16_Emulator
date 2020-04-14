import wx
import Frames
import assembler
import sys

class MainFrameClass(Frames.MainFrame):
    def __init__(self, parent):
        Frames.MainFrame.__init__(self, parent)

    def CreateASM(self, event):
        self.statusbar.SetStatusText("Started")
        file_path = self.OpenFilePicker.GetPath()
        try:
            asm = assembler.make_asm(file_path)
        except:
            message = str(sys.exc_info()[1])
            wx.MessageDialog(self, message, caption="Error!",
                             style=wx.OK|wx.ICON_ERROR).ShowModal()
            return
        out_file = self.SaveFilePicker.GetPath()
        with open(out_file, "w+") as file:
            file.write(asm)
        self.statusbar.SetStatusText("Completed")


App = wx.App()
MainFrame = MainFrameClass(None)
MainFrame.Show(True)
App.MainLoop()
