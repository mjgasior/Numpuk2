import React, { useEffect } from "react";
import { Hooks } from "./Hooks";
import { UploadDialog } from "./upload/UploadDialog";

function App() {
  useEffect(() => {
    fetch("weatherforecast")
      .then(resp => resp.json())
      .then(data => {
        console.log(data);
      });
  }, []);

  return (
    <div className="App">
      <UploadDialog />
      <Hooks />
    </div>
  );
}

export default App;
