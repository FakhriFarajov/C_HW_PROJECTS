import './App.css';
import Task1 from "./components/Task1"
import Task2 from "./components/Task2"
import Task3 from "./components/Task3"
import Task4 from "./components/Task4"

function App() {
  return (
    <div>
      <Task1 name="Lilo And Stitch" author="Chris Sanders" year="2002" />
      <Task2 name="Fakhri" phoneNumber="+994123123123" city="Baku" Skills="C++, C#, JS, SQL"></Task2>
      <Task3></Task3>
      <Task4 name="Cat"></Task4>
    </div>
  );
}

export default App;