import React from "react";
import { useDropzone } from "react-dropzone";

export const Dropzone = ({ onDrop, accept }) => {
  const { getRootProps, getInputProps, isDragActive } = useDropzone({
    onDrop,
    accept
  });

  return (
    <div {...getRootProps()}>
      <input className="dropzone-input" {...getInputProps()} />
      <div className="text-center">
        {isDragActive ? (
          <p className="dropzone-content">Upuść pliki tutaj</p>
        ) : (
          <p className="dropzone-content">
            Przeciągnij tutaj folder z plikami lub kliknij aby dodać
          </p>
        )}
      </div>
    </div>
  );
};
