export default {
  extends: ['@commitlint/config-conventional'],
  parserPreset: 'conventional-changelog-conventionalcommits',

  rules: {
    'header-max-length': [2, 'always', 100],
  },

  prompt: {
    settings: {
      useExclamationMark: true,
    },

    messages: {
      skip: ':skip',
      max: 'maks. %d tegn',
      min: 'mindst %d tegn',
      emptyWarning: 'feltet må ikke være tomt',
      upperLimitWarning: 'teksten er for lang',
      lowerLimitWarning: 'teksten er for kort',
    },

    questions: {
      type: {
        description: 'Vælg typen af ændring:',
        enum: {
          feat: {
            description: 'Ny funktionalitet',
            title: 'Features',
            emoji: '✨',
          },
          fix: {
            description: 'Fejlrettelse',
            title: 'Bug Fixes',
            emoji: '🐛',
          },
          docs: {
            description: 'Dokumentation',
            title: 'Documentation',
            emoji: '📚',
          },
          refactor: {
            description: 'Omstrukturering uden ændret funktionalitet',
            title: 'Refactoring',
            emoji: '📦',
          },
          test: {
            description: 'Tilføj eller ret tests',
            title: 'Tests',
            emoji: '🚨',
          },
          build: {
            description: 'Buildsystem eller dependencies',
            title: 'Build',
            emoji: '🛠️',
          },
          chore: {
            description: 'Vedligeholdelse og øvrige ændringer',
            title: 'Chores',
            emoji: '♻️',
          },
        },
      },

      scope: {
        description: 'Hvilket område påvirkes?',
      },

      subject: {
        description: 'Skriv en kort beskrivelse af ændringen',
      },

      body: {
        description: 'Skriv eventuelt en længere beskrivelse',
      },

      isBreaking: {
        description: 'Indeholder ændringen breaking changes?',
      },

      breaking: {
        description: 'Beskriv breaking changes',
      },

      isIssueAffected: {
        description: 'Påvirker ændringen et issue?',
      },

      issues: {
        description: 'Tilføj issue-reference, eksempelvis "fix #123"',
      },
    },
  },
};