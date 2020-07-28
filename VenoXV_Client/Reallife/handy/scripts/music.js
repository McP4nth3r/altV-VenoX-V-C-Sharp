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
CreateStreamEntrys("I Love Radio",     "https://streams.ilovemusic.de/iloveradio1.mp3");
CreateStreamEntrys("I Love 2 Dance",     "https://streams.ilovemusic.de/iloveradio2.mp3");
CreateStreamEntrys("I Love Deutschrap",       "https://streams.ilovemusic.de/iloveradio6.mp3");
CreateStreamEntrys("I Love The Club",      "https://streams.ilovemusic.de/iloveradio20.mp3");
CreateStreamEntrys("I Love Top 100 Charts",    "https://streams.ilovemusic.de/iloveradio9.mp3");
CreateStreamEntrys("I Love X-Mas",      "https://streams.ilovemusic.de/iloveradio8.mp3");
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
}
RefreshStreamLinks();


$('.VenoXStream').click(function(){
    if(_CurrentStream){ _CurrentStream.pause(); }
    let CurrentClickedElement = $(this).attr('id');
    let NewObj = document.getElementById(CurrentClickedElement);
    _CurrentStream = NewObj;
    NewObj.volume = _CurrentVolume;
    NewObj.play();
});


$('.MusicVolumeClick').click(function(){
    if(!_CurrentStream){ return; }
    let CurrentClickedElement = $(this).attr('id');
    if(CurrentClickedElement == 1 && _CurrentVolume < 0.9){ _CurrentStream.volume += 0.1;}
    else if(CurrentClickedElement == 0 && _CurrentVolume > 0.1){ _CurrentStream.volume -= 0.1;}
    console.log(_CurrentStream.volume);
    _CurrentVolume = _CurrentStream.volume;
});


$('.MusicStopClick').click(function(){
    if(!_CurrentStream){ return; }
    if(_CurrentStream){ _CurrentStream.pause(); }
});

$('.AddMusic').click(function(){
    
});
