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
    this.state = { hubConnection: null, message: "", progress: 0 };
  }

  componentDidMount = () => {
    const hubConnection = new HubConnectionBuilder()
      .withUrl("https://localhost:44392/filesHub")
      .build();

    this.setState({ hubConnection }, () => {
      this.state.hubConnection
        .start()
        .then(() => {
          console.log("Connection started!");
          this.state.hubConnection
            .invoke("SendFiles", this.props.files)
            .catch(err => console.error(err));
        })
        .catch(err => console.log("Error while establishing connection :("));

      this.state.hubConnection.on("FilesAccepted", message =>
        this.setState({ message })
      );

      this.state.hubConnection.on(
        "FileProcessed",
        ({ fileName, fileNumber, totalCount }) => {
          this.setState({
            message: fileName,
            progress: (fileNumber / totalCount) * 100
          });
        }
      );

      this.state.hubConnection.on("AllFilesDone", this.props.onDone);
    });
  };

  render() {
    return (
      <Container>
        <div>{this.state.message}</div>
        <LinearProgress variant="determinate" value={this.state.progress} />
      </Container>
    );
  }
}
