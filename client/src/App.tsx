import { Activity, useEffect, useState } from "react";

function App() {
  //gli state sono variabili che mantengono il loro valore tra i render del componente
  const[activities, setActivities] = useState<Activity[]>([]);

  //questa funzione useEffect viene eseguita una volta al montaggio del componente
  useEffect(() => {
    //il fetch deve fare richiesta al url corretto dove gira il server API
    fetch('https://localhost:5001/api/Activities')
      .then(response => response.json())
      .then(data => setActivities(data));

      return () => {};
  }, []);

  return (
    <div>
    <h3 className="app" style={{color:'red'}}>Reactivities</h3>
    <ul>
      {activities.map(activity => (
        <li key={activity.id}>{activity.title}</li>
      ))}
    </ul>
    </div>
  )
}

export default App
