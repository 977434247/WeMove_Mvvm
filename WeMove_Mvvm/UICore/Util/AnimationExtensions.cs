using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using WeMove_Mvvm.Views.Sign;

namespace WeMove_Mvvm.Views.Sign
{
    public static class AnimationExtensions
    {
        public static async Task SlideAndFadeInAsync(this FrameworkElement element, AnimationDirection direction, float seconds = 0.3f, bool keepMargin = true, int size = 0, bool firstLoad = false)
        {
            // 新建一个故事板
            var sb = new Storyboard();

            switch (direction)
            {
                case AnimationDirection.None:
                    break;
                case AnimationDirection.FromLeft:
                    sb.AddSlideFromLeft(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                case AnimationDirection.FromRight:
                    sb.AddSlideFromRight(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                case AnimationDirection.ToLeft:
                    break;
                case AnimationDirection.ToRight:
                    break;
                default:
                    break;
            }



            // 添加动画淡入
            sb.AddFadeIn(seconds);

            // 开始动画
            sb.Begin(element);

            // 使页面可见，只有当我们是动画或它的第一次加载
            if (seconds != 0 || firstLoad)
                element.Visibility = Visibility.Visible;

            // 等待它结束
            await Task.Delay((int)(seconds * 1000));
        }


        public static async Task SlideAndFadeOutAsync(this FrameworkElement element, AnimationDirection direction, float seconds = 0.3f, bool keepMargin = true, int size = 0, bool firstLoad = false)
        {
            // 新建一个故事板
            var sb = new Storyboard();

            switch (direction)
            {
                case AnimationDirection.None:
                    break;
                case AnimationDirection.FromLeft:
                    break;
                case AnimationDirection.FromRight:
                    break;
                case AnimationDirection.ToLeft:
                    sb.AddSlideToLeft(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                case AnimationDirection.ToRight:
                    sb.AddSlideToRight(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                default:
                    break;
            }


            // 添加动画淡入
            sb.AddFadeOut(seconds);

            // 开始动画
            sb.Begin(element);

            // 使页面可见，只有当我们是动画或它的第一次加载
            if (seconds != 0 || firstLoad)
                element.Visibility = Visibility.Visible;

            // 等待它结束
            await Task.Delay((int)(seconds * 1000));
            element.Visibility = Visibility.Hidden;
        }



    }



    /// <summary>
    /// 【To Out】
    /// </summary>
    public static class SlideTo
    {

        /// <summary>
        /// 【Out】滑到右
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds"></param>
        /// <param name="offset"></param>
        /// <param name="decelerationRatio"></param>
        /// <param name="keepMargin"></param>
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // 从右侧创建页边距动画
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                DecelerationRatio = decelerationRatio
            };

            // 设置目标属性名
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // 将其添加到故事板中
            storyboard.Children.Add(animation);
        }

        public static void AddSlideToRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // 从右侧创建页边距动画
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                DecelerationRatio = decelerationRatio
            };

            // 设置目标属性名
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // 将其添加到故事板中
            storyboard.Children.Add(animation);
        }

    }

    /// <summary>
    /// 【From In】
    /// </summary>
    public static class SildeForm
    {

        /// <summary>
        /// 【In】从左边创建动画边框
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds"></param>
        /// <param name="offset"></param>
        /// <param name="decelerationRatio"></param>
        /// <param name="keepMargin"></param>
        public static void AddSlideFromLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // 从右侧创建页边距动画
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // 设置目标属性名
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // 将其添加到故事板中
            storyboard.Children.Add(animation);
        }

        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // 从右侧创建页边距动画
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // 设置目标属性名
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // 将其添加到故事板中
            storyboard.Children.Add(animation);
        }

    }

    /// <summary>
    /// 淡入 淡出
    /// </summary>
    public static class FadeInOut
    {

        /// <summary>
        /// 【In】淡入
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds"></param>
        /// <param name="from"></param>
        public static void AddFadeIn(this Storyboard storyboard, float seconds, bool from = false)
        {
            // 从右侧创建页边距动画
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                To = 1,
            };

            // 如果需要from 则创建从0开始
            if (from)
                animation.From = 0;

            // 设置目标属性名
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // 将其添加到故事板中
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// 【Out】淡出
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds"></param>
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            // 从右侧创建页边距动画
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                To = 0,
            };

            // 设置目标属性名
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // 将其添加到故事板中
            storyboard.Children.Add(animation);
        }
    }
}
