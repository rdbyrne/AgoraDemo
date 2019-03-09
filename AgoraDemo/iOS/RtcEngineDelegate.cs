using System;
using DT.Xamarin.Agora;

namespace AgoraDemo.iOS
{
    public class RtcEngineDelegate : AgoraRtcEngineDelegate
    {
        private ViewController _controller;

        public RtcEngineDelegate(ViewController controller) : base()
        {
            _controller = controller;
        }

        public override void DidJoinedOfUid(AgoraRtcEngineKit engine, nuint uid, nint elapsed)
        {
            //Debug.WriteLine($"DidJoinedOfUid {uid}");
        }

        public override void FirstRemoteVideoDecodedOfUid(AgoraRtcEngineKit engine, nuint uid, CoreGraphics.CGSize size, nint elapsed)
        {
            //Debug.WriteLine($"FirstRemoteVideoDecodedOfUid {uid}");
            _controller.SetRemoteVideo(engine, uid, size, elapsed);
        }

        public override void DidOfflineOfUid(AgoraRtcEngineKit engine, nuint uid, UserOfflineReason reason)
        {
            //Debug.WriteLine($"DidOfflineOfUid {uid}");
            //_controller.DidOfflineOfUid(engine, uid, reason);
        }

        public override void DidVideoMuted(AgoraRtcEngineKit engine, bool muted, nuint uid)
        {
            //_controller.DidVideoMuted(engine, muted, uid);
        }

        public override void FirstLocalVideoFrameWithSize(AgoraRtcEngineKit engine, CoreGraphics.CGSize size, nint elapsed)
        {
            //_controller.FirstLocalVideoFrameWithSize(engine, size, elapsed);
        }
    }
}
