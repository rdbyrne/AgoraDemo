// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AgoraDemo.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ContainerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton EndCallButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView LocalView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton MuteAudioButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton MuteVideoButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SwitchCameraButton { get; set; }

        [Action ("EndCall:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void EndCall (UIKit.UIButton sender);

        [Action ("MuteAudio:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void MuteAudio (UIKit.UIButton sender);

        [Action ("MuteVideo:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void MuteVideo (UIKit.UIButton sender);

        [Action ("SwitchCamera:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SwitchCamera (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ContainerView != null) {
                ContainerView.Dispose ();
                ContainerView = null;
            }

            if (EndCallButton != null) {
                EndCallButton.Dispose ();
                EndCallButton = null;
            }

            if (LocalView != null) {
                LocalView.Dispose ();
                LocalView = null;
            }

            if (MuteAudioButton != null) {
                MuteAudioButton.Dispose ();
                MuteAudioButton = null;
            }

            if (MuteVideoButton != null) {
                MuteVideoButton.Dispose ();
                MuteVideoButton = null;
            }

            if (SwitchCameraButton != null) {
                SwitchCameraButton.Dispose ();
                SwitchCameraButton = null;
            }
        }
    }
}