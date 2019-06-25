using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ZFSDomain.Common.Other
{
    public class PlayAnimation
    {
        /// <summary>
        /// 展开动画
        /// </summary>
        /// <param name="dependency"></param>
        public static void MediaBeginShow(DependencyObject dependency, double Height = 300)
        {
            System.Windows.Media.Animation.Storyboard sb = new System.Windows.Media.Animation.Storyboard();
            System.Windows.Media.Animation.ThicknessAnimation dmargin = new System.Windows.Media.Animation.ThicknessAnimation();
            dmargin.Duration = new TimeSpan(0, 0, 0, 0, 300);
            dmargin.From = new Thickness(0, Height, 0, Height);
            dmargin.To = new Thickness(0, 0, 0, 0);
            System.Windows.Media.Animation.Storyboard.SetTarget(dmargin, dependency);
            System.Windows.Media.Animation.Storyboard.SetTargetProperty(dmargin, new PropertyPath("Margin", new object[] { }));
            sb.Children.Add(dmargin);
            sb.Begin();
        }

        /// <summary>
        /// 关闭动画
        /// </summary>
        /// <param name="dependency"></param>
        /// <param name="action"></param>
        public static void MediaBeginClose(DependencyObject dependency, Action action, double Height = 300)
        {
            System.Windows.Media.Animation.Storyboard sb = new System.Windows.Media.Animation.Storyboard();
            System.Windows.Media.Animation.ThicknessAnimation dmargin = new System.Windows.Media.Animation.ThicknessAnimation();
            dmargin.Duration = new TimeSpan(0, 0, 0, 0, 300);
            dmargin.From = new Thickness(0, 0, 0, 0);
            dmargin.To = new Thickness(0, Height, 0, Height);
            System.Windows.Media.Animation.Storyboard.SetTarget(dmargin, dependency);
            System.Windows.Media.Animation.Storyboard.SetTargetProperty(dmargin, new PropertyPath("Margin", new object[] { }));
            sb.Children.Add(dmargin);
            sb.Completed += (sender, e) => action();
            sb.Begin();
        }

    }
}
