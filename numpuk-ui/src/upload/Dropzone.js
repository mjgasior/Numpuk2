import React from "react";
import { useDropzone } from "react-dropzone";
import styled from 'styled-components';

const DropField = styled.div`
  padding: 30px;
  border: 2px dashed #3f51b5;
  border-radius: 5px;
`;

const DropStopField = styled(DropField)`
  border-color: #8b96d2;
`;

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
          <DropStopField className="dropzone-content">Upuść pliki tutaj</DropStopField>
        ) : (
          <DropField className="dropzone-content">
            Przeciągnij tutaj folder z plikami lub kliknij aby dodać
          </DropField>
        )}
      </div>
    </div>
  );
};
