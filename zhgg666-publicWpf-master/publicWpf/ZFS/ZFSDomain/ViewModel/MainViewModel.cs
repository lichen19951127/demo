/*
   绑定视图：MainWindow.xaml
   文件说明：控制首页核心功能, 左侧菜单, 右上角工具栏,TabControl面板Open/Close
*/
 
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZFSDomain.Common.CoreLib;
using ZFSDomain.ViewModel.Step;
using ZFSInterface.User;
using System.Linq;
using ZFSData;
using GalaSoft.MvvmLight.Command;
using ZFSDomain.Interface.Base;
using System.Windows.Controls;
using ZFSDomain.Common.UserControls;
using System;
using ZFSData.InterFace.User;
using System.Threading;
using System.Threading.Tasks;
using ZFSDomain.Common.CoreLib.Helper;
using ZFSDomain.Common.UserControls.Common;
using ZFSDomain.SysModule;
using GalaSoft.MvvmLight.Messaging;
using ZFSDomain.View.User;

namespace ZFSDomain.ViewModel
{
    /// <summary>
    /// 首页
    /// </summary>
    public class MainViewModel : BaseHostDialogOperation
    {
        #region 模块系统

        private ModuleManager _ModuleManager;

        public ObservableCollection<PageInfo> OpenPageCollection { get; set; } = new ObservableCollection<PageInfo>();

        /// <summary>
        /// 模块管理器
        /// </summary>
        public ModuleManager ModuleManager
        {
            get { return _ModuleManager; }
        }

        #endregion

        #region 工具栏

        private PopBoxViewModel _PopBoxView;

        /// <summary>
        /// 辅助窗口
        /// </summary>
        public PopBoxViewModel PopBoxView
        {
            get { return _PopBoxView; }
        }

        private NoticeViewModel _NoticeView;

        /// <summary>
        /// 通知模块
        /// </summary>
        public NoticeViewModel NoticeView
        {
            get { return _NoticeView; }
        }

        #endregion

        #region 命令(Binding Command)

        private object _CurrentPage;

        /// <summary>
        /// 当前选择页
        /// </summary>
        public object CurrentPage
        {
            get { return _CurrentPage; }
            set { _CurrentPage = value; RaisePropertyChanged(); }
        }

        private RelayCommand<Module> _ExcuteCommand;
        private RelayCommand<PageInfo> _ExitCommand;

        /// <summary>
        /// 打开页
        /// </summary>
        public RelayCommand<Module> ExcuteCommand
        {
            get
            {
                if (_ExcuteCommand == null)
                {
                    _ExcuteCommand = new RelayCommand<Module>(t => Excute(t));
                }
                return _ExcuteCommand;
            }
            set { _ExcuteCommand = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 关闭页
        /// </summary>
        public RelayCommand<PageInfo> ExitCommand
        {
            get
            {
                if (_ExitCommand == null)
                {
                    _ExitCommand = new RelayCommand<PageInfo>(t => ExitPage(t));
                }
                return _ExitCommand;
            }
            set { _ExitCommand = value; RaisePropertyChanged(); }
        }

        #endregion

        #region 初始化/页面相关

        /// <summary>
        /// 初始化首页
        /// </summary>
        public void InitDefaultView()
        {
            //初始化工具栏,通知窗口
            _PopBoxView = new PopBoxViewModel();
            _NoticeView = new NoticeViewModel();
            //加载窗体模块
            _ModuleManager = new ModuleManager();
            _ModuleManager.LoadModules();
            //设置系统默认首页
            var page = OpenPageCollection.FirstOrDefault(t => t.HeaderName.Equals("系统首页"));
            if (page == null)
            {
                HomeAbout about = new HomeAbout();
                OpenPageCollection.Add(new PageInfo() { HeaderName = "系统首页", Body = about });
                CurrentPage = about;
            }
        }

        /// <summary>
        /// 执行模块
        /// </summary>
        /// <param name="module"></param>
        private async void Excute(Module module)
        {
            try
            {
                var page = OpenPageCollection.FirstOrDefault(t => t.HeaderName.Equals(module.Name));
                if (page != null) { CurrentPage = page.Body; return; }
                if (module.ModNameSpcae == null)
                {
                    DefaultViewPage defaultViewPage = new DefaultViewPage();
                    OpenPageCollection.Add(new PageInfo() { HeaderName = module.Name, Body = defaultViewPage });
                    CurrentPage = defaultViewPage;
                }
                else
                {
                    await Task.Run(() =>
                   {
                       App.Current.Dispatcher.Invoke(() =>
                      {
                          var ass = System.Reflection.Assembly.GetExecutingAssembly();
                          if (ass.CreateInstance(module.ModNameSpcae) is IModel dialog)
                          {
                              dialog.BindDefaultModel(module.Authorities);
                              OpenPageCollection.Add(new PageInfo() { HeaderName = module.Name, Body = dialog.GetView() });
                          }
                      });
                   });
                }
                CurrentPage = OpenPageCollection[OpenPageCollection.Count - 1].Body;
            }
            catch (Exception ex)
            {
                Msg.Error(ex.Message, false);
            }
            finally
            {
                Messenger.Default.Send(false, "PackUp");
                GC.Collect();
            }
        }

        /// <summary>
        /// 关闭页面
        /// </summary>
        /// <param name="module"></param>
        private void ExitPage(PageInfo module)
        {
            try
            {
                var tab = OpenPageCollection.FirstOrDefault(t => t.HeaderName.Equals(module.HeaderName));
                if (tab.HeaderName != "系统首页") OpenPageCollection.Remove(tab);
            }
            catch (Exception ex)
            {
                Msg.Error(ex.Message);
            }
        }

        #endregion
    }
}