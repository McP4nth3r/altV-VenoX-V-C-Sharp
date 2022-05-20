Vue.config.devtools = true;
Vue.prototype.window = window;

const app = new Vue({
    el: "#app",
    data() {
        return {
            backgrounds: [
        "files/images/wallpaper/bg-0.png",
        "files/images/wallpaper/bg-1.jpg",
        "files/images/wallpaper/bg-2.png",
        "files/images/wallpaper/bg-3.png",
        "files/images/wallpaper/bg-4.png",
        "files/images/wallpaper/bg-5.png",
        "files/images/wallpaper/bg-6.png",
        "files/images/wallpaper/bg-7.png",
        "files/images/wallpaper/bg-8.png",
        "files/images/wallpaper/bg-9.png",
        "files/images/wallpaper/bg-10.png",
      ],
            characters: [
        "files/images/wallpaper/bg-0-char.png",
        "files/images/wallpaper/bg-1-char.png",
        "files/images/wallpaper/bg-2-char.png",
        "files/images/wallpaper/bg-3-char.png",
        "files/images/wallpaper/bg-4-char.png",
        "files/images/wallpaper/bg-5-char.png",
        "files/images/wallpaper/bg-6-char.png",
        "files/images/wallpaper/bg-7-char.png",
        "files/images/wallpaper/bg-8-char.png",
        "files/images/wallpaper/bg-9-char.png",
        "files/images/wallpaper/bg-10-char.png",
      ],
            currentBackground: 0,
            currentCharacter: 0,
            characterAnimationState: 0,
            transitionTime: 5000,
        };
    },
    computed: {},
    methods: {
        nextIndex(array, currentIndex) {
            return array.length == currentIndex ? 0 : currentIndex++;
        },
    },
    mounted() {
        setInterval(() => {
            this.characterAnimationState = Math.round(Math.random() * 1);
            let RandomShow = Math.round(Math.random() * this.backgrounds.length);
            if (RandomShow == this.currentBackground) {
                RandomShow = Math.round(Math.random() * this.backgrounds.length);
            }
            this.currentBackground = RandomShow;
            this.currentCharacter = RandomShow;


            /*
            if (this.currentBackground == this.backgrounds.length) {
                this.currentBackground = 0;
            } else {
                this.currentBackground += 1;
            }

            if (this.currentCharacter == this.characters.length) {
                this.currentCharacter = 0;
            } else {
                this.currentCharacter += 1;
            }*/
        }, this.transitionTime);
    },
});
