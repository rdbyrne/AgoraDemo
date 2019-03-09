using Android.App;
using Android.Widget;
using Android.OS;
using DT.Xamarin.Agora;
using Android;
using System.Threading.Tasks;
using System.Linq;
using Android.Content.PM;
using Android.Support.V4.Content;
using Android.Support.V4.App;
using Android.Views;
using DT.Xamarin.Agora.Video;

namespace AgoraDemo.Droid
{
    [Activity(Label = "AgoraDemo", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        private RtcEventHandler _rtcEventHandler;
        private RtcEngine _rtcEngine;

        private readonly string[] _permissions = new string[] {
            Manifest.Permission.Camera,
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.RecordAudio,
            Manifest.Permission.ModifyAudioSettings,
            Manifest.Permission.Internet,
            Manifest.Permission.AccessNetworkState
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            CheckPermissions();
            _rtcEventHandler = new RtcEventHandler(this);
            _rtcEngine = RtcEngine.Create(BaseContext, "2cb3898040a64b88a9ca9763cc3d5667", _rtcEventHandler);
            _rtcEngine.SetVideoProfile(Constants.ChannelProfileCommunication, false);
            _rtcEngine.EnableVideo();
            SetVideoEncoder();
            SetupLocalVideo();
            JoinChannel();
            // Get our button from the layout resource,
            // and attach an event to it
        }

        private bool CheckPermissions(bool requestPermissions = true)
        {
            var isGranted = _permissions.Select(permission => ContextCompat.CheckSelfPermission(this, permission) == (int)Permission.Granted).All(granted => granted);
            if (requestPermissions && !isGranted)
            {
                ActivityCompat.RequestPermissions(this, _permissions, 0);
            }
            return isGranted;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            //var test = 0;
        }

            public void OnFirstRemoteVideoDecoded(int uid, int width, int height, int elapsed)
        {
            RunOnUiThread(() =>
            {
                SetupRemoteVideo(uid);
            });
        }

        private void JoinChannel()
        {
            _rtcEngine.JoinChannel(null, "DEMOCHANNEL1", "Extra Optional Data", 0); // If you do not specify the uid, Agora will assign one.
        }

        private void SetVideoEncoder()
        {
            VideoEncoderConfiguration.ORIENTATION_MODE
orientationMode =
VideoEncoderConfiguration.ORIENTATION_MODE.OrientationModeFixedPortrait;

            VideoEncoderConfiguration.VideoDimensions dimensions = new VideoEncoderConfiguration.VideoDimensions(360, 640);

            VideoEncoderConfiguration videoEncoderConfiguration = new VideoEncoderConfiguration(dimensions, VideoEncoderConfiguration.FRAME_RATE.FrameRateFps15, VideoEncoderConfiguration.StandardBitrate, orientationMode);

            _rtcEngine.SetVideoEncoderConfiguration(videoEncoderConfiguration);
        }

        private void SetupLocalVideo()
        {
            FrameLayout container = (FrameLayout)FindViewById(Resource.Id.local_video_view_container);
            SurfaceView surfaceView = RtcEngine.CreateRendererView(BaseContext);
            surfaceView.SetZOrderMediaOverlay(true);
            container.AddView(surfaceView);
            _rtcEngine.SetupLocalVideo(new VideoCanvas(surfaceView, VideoCanvas.RenderModeAdaptive, 0));
        }

        private void SetupRemoteVideo(int uid)
        {
            //_remoteId = (uint)uid;
            FrameLayout container = (FrameLayout)FindViewById(Resource.Id.remote_video_view_container);
            if (container.ChildCount >= 1)
            {
                return;
            }
            SurfaceView surfaceView = RtcEngine.CreateRendererView(BaseContext);
            container.AddView(surfaceView);
            _rtcEngine.SetupRemoteVideo(new VideoCanvas(surfaceView, VideoCanvas.RenderModeAdaptive, uid));
            surfaceView.Tag = uid;
        }
    }
}

