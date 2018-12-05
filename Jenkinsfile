pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        powershell(script: 'build.ps1', returnStdout: true, returnStatus: true)
      }
    }
    stage('Test') {
      steps {
        powershell(script: 'build.ps1 -Target Test', returnStatus: true, returnStdout: true)
      }
    }
  }
}