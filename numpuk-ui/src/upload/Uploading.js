import React, { Component } from "react";
import { HubConnectionBuilder } from "@microsoft/signalr";
import LinearProgress from "@material-ui/core/LinearProgress";
import styled from "styled-components";

const Container = styled.div`
  padding: 30px;
  display: flex;
  border: 2px dashed #3f51b5;
  border-radius: 5px;
  flex-direction: column;
`;

export class Uploading extends Component {
  constructor(props) {
    super(props);
    this.state = { hubConnection: null, message: "", progress: 0, errorList: [] };
  }

  componentDidMount = () => {
    const hubConnection = new HubConnectionBuilder()
      .withUrl("https://localhost:5001/filesHub")
      .build();

    this.setState({ hubConnection }, () => {
      const { password, directory } = this.props;
      this.state.hubConnection
        .start()
        .then(() => {
          console.log("Connection started!");
          this.state.hubConnection
            .invoke("SendDirectory", { password, directory })
            .catch(err => console.error(err));
        })
        .catch(err => console.log("Error while establishing connection :("));

      this.state.hubConnection.on("FilesAccepted", message =>
        this.setState({ message })
      );

      this.state.hubConnection.on(
        "FileProcessed",
        ({ fileName, fileNumber, totalCount, error }) => {
          this.setState({
            message: fileName,
            progress: (fileNumber / totalCount) * 100
          });

          if (error) {
            console.log(fileName + " @ " + error);
            const newProblem = fileName + " @ " + error;
            this.setState(prev => {
              const errors = [...prev.errorList, newProblem];
              return { ...prev, errorList: errors };
            });
          }
        }
      );

      this.state.hubConnection.on("AllFilesDone", this.props.onDone);
    });
  };

  render() {
    const { message, progress, errorList } = this.state;
    return (
      <Container>
        <div>{message}</div>
        <LinearProgress variant="determinate" value={progress} />
        {errorList.length > 0 && errorList.map(x => <div key={x}>{x}</div>)}
      </Container>
    );
  }
}
