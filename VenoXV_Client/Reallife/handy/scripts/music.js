//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By LargePeach & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

let _StreamLinks = [];
let _StreamCounter = 0;
let _CurrentStream;
let _CurrentVolume = 0.01;

function CreateStreamEntrys(_EntryName, _EntrySource){
    _StreamLinks[_StreamCounter++] = {
        Name: _EntryName,
        Source: _EntrySource
    };
}
//BasicStream Links.
CreateStreamEntrys("1 LIVE",                    "https://wdr-1live-live.sslcast.addradio.de/wdr/1live/live/mp3/128/stream.mp3?ar-key=BcG5DcAgEATAYiwRIvY-9gKKwSdTggNX75l34Wu1KB3IDo7O9iy4SpAAFH6pVYzct5Ql_XBIGI_uWZE2PX4");
CreateStreamEntrys("Big FM",                    "http://streams.bigfm.de/bigfm-deutschland-128-aac?usid=0-0-H-A-D-30");
CreateStreamEntrys("Big FM Deutsch Rap",        "http://streams.bigfm.de/bigfm-deutschrap-128-mp3");
CreateStreamEntrys("Blackbeats.FM",             "http://stream.blackbeatslive.de/");
CreateStreamEntrys("Deutschlandfunk",           "http://st01.dlf.de/dlf/01/128/mp3/stream.mp3");
CreateStreamEntrys("Energy Wien 104.2",         "http://cdn.nrjaudio.fm/adwz1/at/36005/mp3_128.mp3");
CreateStreamEntrys("Germany Top 100 Station",   "http://stream.laut.fm/top100germany");
CreateStreamEntrys("I Love Radio",              "https://streams.ilovemusic.de/iloveradio1.mp3");
CreateStreamEntrys("I Love Deutschrap",         "https://streams.ilovemusic.de/iloveradio6.mp3");
CreateStreamEntrys("I Love Top 100 Charts",     "https://streams.ilovemusic.de/iloveradio9.mp3");
CreateStreamEntrys("Kiss FM",                   "http://stream.kissfm.de/kissfm/mp3-128/internetradio/");
CreateStreamEntrys("SWR 3",                     "http://swr-swr3-live.cast.addradio.de/swr/swr3/live/mp3/128/stream.mp3");
CreateStreamEntrys("TechnoBase.FM",             "http://mp3.stream.tb-group.fm/tb.mp3");
CreateStreamEntrys("WDR 2",                     "https://wdr-wdr2-rheinland.icecastssl.wdr.de/wdr/wdr2/rheinland/mp3/128/stream.mp3");
CreateStreamEntrys("WDR 4",                     "https://wdr-wdr4-live.icecastssl.wdr.de/wdr/wdr4/live/mp3/128/stream.mp3");


//BasicStream Links.

function RefreshStreamLinks(){
    let d = 0;
    $('.musicscreenGridbg').empty();
    for(let _c in _StreamLinks){
        $('.musicscreenGridbg').append('<audio controls id="VenoXStream_'+ _c + '" type="audio/mp3" src="'+ _StreamLinks[_c].Source +'" class="AudioStreamColumn d-none"></audio>');
        if (d == 0) {
            $('.musicscreenGridbg').append('<div id="VenoXStream_'+ _c + '" class="VenoXStream screenline"><div class="Username">' + _StreamLinks[_c].Name + '</div></div>');
            d++;
        }
        else {
            $('.musicscreenGridbg').append('<div id="VenoXStream_'+ _c + '" class="VenoXStream screenlinedark"><div class="Username">' + _StreamLinks[_c].Name + '</div></div>');
            d--;
        }
    }
    $('.VenoXStream').click(function(){
        if(_CurrentStream){ _CurrentStream.pause(); }
        let CurrentClickedElement = $(this).attr('id');
        let NewObj = document.getElementById(CurrentClickedElement);
        _CurrentStream = NewObj;
        NewObj.volume = _CurrentVolume;
        NewObj.play();
    });
}
RefreshStreamLinks();


$('.MusicVolumeClick').click(function(){
    if(!_CurrentStream){ return; }
    let CurrentClickedElement = $(this).attr('id');
    if(CurrentClickedElement == 1 && _CurrentVolume < 0.9){ _CurrentStream.volume += 0.1;}
    else if(CurrentClickedElement == 0 && _CurrentVolume > 0.1){ _CurrentStream.volume -= 0.1;}
    _CurrentVolume = _CurrentStream.volume;
});


$('.MusicStopClick').click(function(){
    if(!_CurrentStream){ return; }
    if(_CurrentStream){ _CurrentStream.pause(); }
});

$('.AddMusic').click(function(){
    let Name = $('#NewMusicName').val();
    let Link = $('#NewMusicLink').val();
    if(Name.length <= 1){ return; }
    if(Link.length <= 1){ return; }
    CreateStreamEntrys(Name, Link);
    RefreshStreamLinks();
});
