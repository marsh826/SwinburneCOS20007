class Counter {
    constructor(name){
        this.Name = name;
        this.Count = 0;
    }

    increment(){
        this.Count++;
    }

    reset(){
        this.Count = 0;
    }
}

var hour = new Counter();
var minute = new Counter();
var second = new Counter();

var start = false;

function updateDisplay(){
    document.getElementById("hour").innerHTML 
    = hour.Count.toLocaleString('en-US', {minimumIntegerDigits: 2, useGrouping:false});
document.getElementById("minute").innerHTML 
    = minute.Count.toLocaleString('en-US', {minimumIntegerDigits: 2, useGrouping:false});
document.getElementById("second").innerHTML 
    = second.Count.toLocaleString('en-US', {minimumIntegerDigits: 2, useGrouping:false});
}


function clockTick(){
    const myInterval = setInterval(() => {
        console.log(start);
        if(start == true){
            second.increment();
            updateDisplay();
            if(second.Count > 59){
                second.reset();
                updateDisplay();
                minute.increment();
                updateDisplay();
            }

            if(minute.Count > 59){
                second.reset();
                updateDisplay();
                minute.reset();
                updateDisplay();
                hour.increment();
                updateDisplay();
            }

            if(hour.Count > 23){
                resetClock();
            }
        }
        else{
            //clearInterval(myInterval)
        }
    }, 1000);
}

function startClock(){
    start = true;
    console.log(start);

}

function stopClock(){
    start = false;
}

function addtick(){
    second.increment();
    updateDisplay();
}

function resetClock(){
    second.reset();
    minute.reset();
    hour.reset();
    updateDisplay();
}

document.getElementById("hour").innerHTML 
    = hour.Count.toLocaleString('en-US', {minimumIntegerDigits: 2, useGrouping:false});
document.getElementById("minute").innerHTML 
    = minute.Count.toLocaleString('en-US', {minimumIntegerDigits: 2, useGrouping:false});
document.getElementById("second").innerHTML 
    = second.Count.toLocaleString('en-US', {minimumIntegerDigits: 2, useGrouping:false});

window.onload = clockTick();