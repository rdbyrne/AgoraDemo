using System;
using DT.Xamarin.Agora;
using UIKit;

namespace AgoraDemo.iOS
{
    public partial class ViewController : UIViewController
    {
        private AgoraRtcEngineKit _rtcEngine;
        private RtcEngineDelegate _rtcEngineDeletegate;

        private bool _audioMuted = false;
        private bool _videoMuted = false;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _rtcEngineDeletegate = new RtcEngineDelegate(this);
            _rtcEngine = AgoraRtcEngineKit.SharedEngineWithAppIdAndDelegate("2cb3898040a64b88a9ca9763cc3d5667", _rtcEngineDeletegate);
            _rtcEngine.SetChannelProfile(ChannelProfile.Communication);
            _rtcEngine.EnableVideo();

            AgoraRtcVideoCanvas videoCanvas = new AgoraRtcVideoCanvas
            {
                Uid = 0,
                View = LocalView,
                RenderMode = VideoRenderMode.Adaptive
            };
            _rtcEngine.SetupLocalVideo(videoCanvas);
            _rtcEngine.JoinChannelByToken(string.Empty, "DEMOCHANNEL1", null, 0, JoinSuccessful);
        }

        public void SetRemoteVideo(AgoraRtcEngineKit engine, nuint uid, CoreGraphics.CGSize size, nint elapse)
        {
            AgoraRtcVideoCanvas videoCanvas = new AgoraRtcVideoCanvas
            {
                Uid = uid,
                View = ContainerView,
                RenderMode = VideoRenderMode.Adaptive
            };
            _rtcEngine.SetupRemoteVideo(videoCanvas);
        }

        private void JoinSuccessful(Foundation.NSString channel, nuint uid, nint elapsed)
        {
            _rtcEngine.SetEnableSpeakerphone(true);
            UIApplication.SharedApplication.IdleTimerDisabled = true;
        }

        partial void SwitchCamera(UIButton sender)
        {
            _rtcEngine.SwitchCamera();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

        partial void MuteVideo(UIButton sender)
        {
            _videoMuted = !_videoMuted;
            MuteVideoButton.Selected = _videoMuted;
            LocalView.Hidden = _videoMuted;
            SwitchCameraButton.Hidden = _videoMuted;
            _rtcEngine.MuteLocalVideoStream(_videoMuted);
        }

        partial void MuteAudio(UIButton sender)
        {
            _audioMuted = !_audioMuted;
            MuteAudioButton.Selected = _audioMuted;
            _rtcEngine.MuteLocalAudioStream(_videoMuted);
        }

        partial void EndCall(UIButton sender)
        {
            _rtcEngine.LeaveChannel(null);
            LocalView.Hidden = true;
        }
    }
}
