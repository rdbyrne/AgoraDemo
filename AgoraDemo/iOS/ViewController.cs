using System;
using DT.Xamarin.Agora;
using UIKit;

namespace AgoraDemo.iOS
{
    public partial class ViewController : UIViewController
    {
        private AgoraRtcEngineKit _rtcEngine;
        private RtcEngineDelegate _rtcEngineDeletegate;

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

        //        private void SetVideoEncoder()
        //        {
        //            var configuration = new AgoraVideoEncoderConfiguration(AgoraVideoDimension640x360,)

        //            let configuration = AgoraVideoEncoderConfiguration(size:
        //AgoraVideoDimension640x360, frameRate: .fps15, bitrate: 400,
        //orientationMode: .fixedPortrait)
        //agoraKit.setVideoEncoderConfiguration(configuration)
        //}

//        func setupRemoteVideo()
//        {
//            let videoCanvas = AgoraRtcVideoCanvas()
//    videoCanvas.uid = 1
//    videoCanvas.view = remoteVideo
//    videoCanvas.renderMode = .fit
//    agoraKit.setupRemoteVideo(videoCanvas)
//}

        public void SetRemoteVideo(AgoraRtcEngineKit engine, nuint uid, CoreGraphics.CGSize size, nint elapse)
        {
            AgoraRtcVideoCanvas videoCanvas = new AgoraRtcVideoCanvas();
            videoCanvas.Uid = uid;
            videoCanvas.View = ContainerView;
            videoCanvas.RenderMode = VideoRenderMode.Adaptive;
            _rtcEngine.SetupRemoteVideo(videoCanvas);
        }

        private void JoinSuccessful(Foundation.NSString channel, nuint uid, nint elapsed)
        {
            //_localId = (uint)uid;
            _rtcEngine.SetEnableSpeakerphone(true);
            UIApplication.SharedApplication.IdleTimerDisabled = true;
            //RefreshDebug();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
