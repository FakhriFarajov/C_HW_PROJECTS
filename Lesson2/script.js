//Task1

function CompareNumbers(a,b){
    if(a<b) {
        return -1; 
    }
    else if(a>b){
        return 1;
    }
    else if(a == b){
        return 0;
    }
}

//Task2

function FindFactorial(a){
    let result = 1;
    for (let index = 1; index <= a; index++) {
        result *= index;
    }
    return result;
}


//Task3
function TransformToNumber(a, b, c) {
    let number = Number(a.toString() + b.toString() + c.toString());
    return number;
}

//Task4
function CalcArea(a,b){
    if(arguments.length == 1){
        return a**2
    }
    return a*b;
}


//Task5
function CompleteNumber(a){
    let sum=0;
    for (let index = 1; index < a; index++) {
        if(index%2 == 0){
            sum += index;
        }
    }
    return sum == a;
}


//Task6
function FindComplete(a,b){
    if(a>b){
        for (let index = b; index <= a; index++) {
            console.log(`The number ${index} is ${CompleteNumber(index)}`);
        }
    }
    else if(a<b){
        for (let index = a; index <= b; index++) {
            console.log(`The number ${index} is ${CompleteNumber(index)}`);
        }
    }
}

//Task7
function getTime(Hour, Min = 0, Sec = 0) {
    Min += Math.floor(Sec / 60);
    Sec = Sec % 60;

    Hour += Math.floor(Min / 60);
    Min = Min % 60;

    let h = Hour.toString().padStart(2, '0');
    let m = Min.toString().padStart(2, '0');
    let s = Sec.toString().padStart(2, '0');

    return `${h}:${m}:${s}`;
}


//Task8
function GetSeconds(Hour,Min,Sec){
    let result = (Hour*3600) + Min*60 + Sec;
    return result;
}

//Task9
function convertSecondsToTime(seconds) {
    let hours = Math.floor(seconds / 3600);           // 1 час = 3600 секунд
    let minutes = Math.floor((seconds % 3600) / 60);  // оставшиеся секунды преобразуем в минуты
    let secs = seconds % 60;                         // оставшиеся секунды


    let h = hours.toString().padStart(2, '0');
    let m = minutes.toString().padStart(2, '0');
    let s = secs.toString().padStart(2, '0');

    return `${h}:${m}:${s}`;
}


//Task10 
function getDifference(h1,m1,s1,h2,m2,s2){
    let a = GetSeconds(h1,m1,s1);
    let b = GetSeconds(h2,m2,s2);

    let result;
    if(a>b){
        a-=b
        result = a;
    }
    else if(a<b){
        b-=a;
        result = b;
    }

    return convertSecondsToTime(result)
}

