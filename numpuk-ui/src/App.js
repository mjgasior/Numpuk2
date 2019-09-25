import React, { useEffect } from "react";
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
    <div>
      <UploadDialog />
    </div>
  );
}

export default App;
